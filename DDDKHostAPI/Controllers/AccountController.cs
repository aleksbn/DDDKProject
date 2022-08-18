using AutoMapper;
using DDDKHostAPI.Models.DTOs;
using DDDKHostAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DDDKHostAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<AccountController> _logger;
        private readonly IMapper _mapper;
        private readonly IAuthManager _authManager;

        public AccountController(UserManager<IdentityUser> userManager, ILogger<AccountController> logger, IMapper mapper, IAuthManager authManager)
        {
            _userManager = userManager;
            _logger = logger;
            _mapper = mapper;
            _authManager = authManager;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO registerDTO)
        {
            _logger.LogInformation($"Registration attempt for {registerDTO.Email}");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!registerDTO.Password.Equals(registerDTO.PasswordConfirmation) || !registerDTO.Email.Equals(registerDTO.EmailConfirmation))
            {
                return BadRequest("Email or password not equal to their confirmation");
            }
            try
            {
                var user = _mapper.Map<IdentityUser>(registerDTO);
                user.UserName = user.Email;
                var result = await _userManager.CreateAsync(user, registerDTO.Password);
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }
                    return BadRequest(ModelState);
                }
                await _userManager.AddToRoleAsync(user, "Moderator");
                return Ok();
            }
            catch (Exception x)
            {
                _logger.LogError(x, $" Something went wrong in the {nameof(Register)} controller.");
                return Problem("Internal server error, please try again", statusCode: 500);
            }
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
        {
            _logger.LogInformation($"Login attempt for {loginDTO.Email}");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                if (!await _authManager.ValidateUser(loginDTO))
                {
                    return Unauthorized("User login attempt failed");
                }
                return Accepted(new
                {
                    Token = await _authManager.CreateToken()
                });
            }
            catch (Exception x)
            {
                _logger.LogError(x, $" Something went wrong in the {nameof(Login)} controller.");
                return Problem("Internal server error, please try again", statusCode: 500);
            }
        }
    }
}
