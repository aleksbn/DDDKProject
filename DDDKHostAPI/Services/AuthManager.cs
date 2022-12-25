using DDDKHostAPI.Models.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DDDKHostAPI.Services
{
    public class AuthManager : IAuthManager
    {
        //4.4.8 Radimo injection potrebnih objekata
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration;
        private IdentityUser _user;
        public AuthManager(UserManager<IdentityUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        //4.4.10 Kreiramo token (odnosi se na sljedece 4 funkcije)
        public async Task<string> CreateToken()
        {
            var signingCredentials = GetSigningCredentials();
            var claims = await GetClaims();
            var token = GenerateTokenOptions(signingCredentials, claims);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var jwtSettings = _configuration.GetSection("Jwt");
            var expiration = DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings.GetSection("lifetime").Value));

            var token = new JwtSecurityToken(
                issuer: jwtSettings.GetSection("Issuer").Value,
                claims: claims,
                expires: expiration,
                signingCredentials: signingCredentials,
                audience: "AllRegisteredUsers"
                );

            return token;
        }

        private async Task<List<Claim>> GetClaims()
        {
            var claims = new List<Claim>
             {
                 new Claim(ClaimTypes.Name, _user.UserName)
             };

            var roles = await _userManager.GetRolesAsync(_user);

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            return claims;
        }

        private SigningCredentials GetSigningCredentials()
        {
            var key = _configuration.GetSection("Jwt").GetSection("Key");
            var secret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key.Value));

            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }
        //4.4.9 Prvo radimo provjeru da li korisnik postoji
        public async Task<bool> ValidateUser(LoginDTO userDTO)
        {
            _user = await _userManager.FindByNameAsync(userDTO.Email);
            var validPassword = await _userManager.CheckPasswordAsync(_user, userDTO.Password);
            return (_user != null && validPassword);
        }
    }
}