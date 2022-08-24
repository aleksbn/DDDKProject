using AutoMapper;
using DDDKHostAPI.Models.Data;
using DDDKHostAPI.Models.DTOs;
using DDDKHostAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        private readonly DatabaseContext _db;

        public AccountController(UserManager<IdentityUser> userManager, ILogger<AccountController> logger, IMapper mapper, IAuthManager authManager, DatabaseContext db)
        {
            _userManager = userManager;
            _logger = logger;
            _mapper = mapper;
            _authManager = authManager;
            _db = db;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ActionName(nameof(Register))]
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
        [ActionName(nameof(Login))]
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

        [Authorize(Roles = "Admin")]
        [HttpPut]
        [ActionName(nameof(UpdateModerator))]
        public async Task<IActionResult> UpdateModerator(string id, [FromBody] UpdateModeratorDTO moderatorDTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateModerator)}");
                return BadRequest(ModelState);
            }

            try
            {
                var user = await _userManager.Users.FirstOrDefaultAsync(q => q.Id.Equals(id));
                if (user == null)
                {
                    _logger.LogError($"That user does not exist");
                    return BadRequest("Invalid user");
                }
                if (moderatorDTO.Password != moderatorDTO.PasswordConfirmation 
                    || moderatorDTO.Email != moderatorDTO.EmailConfirmation)
                {
                    _logger.LogError("Password and its confirmation, or email and its confirmation do not match");
                    return BadRequest("Invalid data");
                }
                if (_db.Users.Count(u => u.Email == moderatorDTO.Email) > 0)
                {
                    _logger.LogError("That email is already taken");
                    return BadRequest("Invalid data");
                }
                _mapper.Map(moderatorDTO, user);
                user.UserName = user.Email;
                await _userManager.UpdateAsync(user);
                _db.SaveChanges();
                return NoContent();
            }
            catch (Exception x)
            {
                _logger.LogError(x, $"Somethoing went wrong in the {nameof(UpdateModerator)}");
                return StatusCode(500, "Internal server error, please try later");
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id:int}")]
        [ActionName(nameof(DeleteModerator))]
        public async Task<IActionResult> DeleteModerator(string id)
        {
            if (id != "")
            {
                _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteModerator)}");
                return BadRequest();
            }

            try
            {
                var user = _userManager.Users.FirstOrDefaultAsync(q => q.Id == id);
                if (user == null)
                {
                    _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteModerator)}");
                    return BadRequest("Submitted data is invalid");
                }
                await _userManager.DeleteAsync(await user);
                _db.SaveChanges();
                return NoContent();
            }
            catch (Exception x)
            {
                _logger.LogError(x, $"Something Went Wrong in the {nameof(DeleteModerator)}");
                return StatusCode(500, "Internal Server Error. Please Try Again Later.");
            }
        }
    }
}
