using MailRemoverAPI.Models.Gmail;
using System.ComponentModel.DataAnnotations;

namespace MailRemoverAPI.Models.User
{
    public class LoginUserDto : BaseUserDto
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
