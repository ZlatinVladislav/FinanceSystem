﻿using System.ComponentModel.DataAnnotations;

namespace FinanceSystem.DtoModels.User
{
    public class RegisterDto
    {
        [Required]
        public string DisplayName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [RegularExpression("(?=.*\\d)(?=.*[a-z])(?=.*[A-Z]).{6,20}$", ErrorMessage = "Password is chosen wrong")]
        public string Password { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Role { get; set; }
    }
}