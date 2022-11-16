using System.ComponentModel.DataAnnotations;

namespace MailRemoverAPI.Models.User
{
    public abstract class BaseUserDto
    {
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
