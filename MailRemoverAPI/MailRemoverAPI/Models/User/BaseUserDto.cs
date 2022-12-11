using System.ComponentModel.DataAnnotations;

namespace MailRemoverAPI.Models.User
{
    public abstract class BaseUserDto
    {
        public string UserEmail { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
