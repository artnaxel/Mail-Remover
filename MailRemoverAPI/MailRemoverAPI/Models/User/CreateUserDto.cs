using System.ComponentModel.DataAnnotations;

namespace MailRemoverAPI.Models.User
{
    public class CreateUserDto
    {
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
