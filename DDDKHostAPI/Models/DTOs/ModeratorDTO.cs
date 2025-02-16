﻿using System.ComponentModel.DataAnnotations;

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
        public string Role { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string PasswordConfirmation { get; set; }
        [Required]
        [EmailAddress]
        public string EmailConfirmation { get; set; }
    }

    public class UpdateModeratorDTO: RegisterDTO
    {
        [Required]
        [EmailAddress]
        public string OldEmail { get; set; }
    }

    public class UserDTO
    {
        public string ID { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}
