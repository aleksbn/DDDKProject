using System.ComponentModel.DataAnnotations;

namespace DDDKHostAPI.Models.DTOs
{
    public class LoginDTO
    {
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }

    public class RegisterDTO: LoginDTO
    {
        [Required]
        [DataType(DataType.Password)]
        public string PasswordConfirmation { get; set; }
        [Required]
        [EmailAddress]
        public string EmailConfirmation { get; set; }
    }

    public class UpdateModeratorDTO: RegisterDTO
    {

    }
}
