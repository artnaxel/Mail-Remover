using MailRemoverAPI.Models.Gmail;
using System.ComponentModel.DataAnnotations;

namespace MailRemoverAPI.Models.User
{
    public class LoginUserDto
    {
        [Required]
        public string UserEmail { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
