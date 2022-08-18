using DDDKHostAPI.Models.DTOs;

namespace DDDKHostAPI.Services
{
    public interface IAuthManager
    {
        Task<bool> ValidateUser(LoginDTO loginDTO);
        Task<string> CreateToken();
    }
}
