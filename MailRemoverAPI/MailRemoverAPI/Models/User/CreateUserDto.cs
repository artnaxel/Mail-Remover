﻿using System.ComponentModel.DataAnnotations;

namespace MailRemoverAPI.Models.User
{
    public class CreateUserDto : BaseUserDto
    {
        [Required]
        public string UserEmail { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
