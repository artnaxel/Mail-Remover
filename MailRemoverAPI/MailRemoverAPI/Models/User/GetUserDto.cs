using System.ComponentModel.DataAnnotations.Schema;

namespace MailRemoverAPI.Models.User
{
    public class GetUserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid UserId { get; set; }
    }
}
