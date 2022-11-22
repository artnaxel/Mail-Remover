using System.ComponentModel.DataAnnotations.Schema;

namespace MailRemoverAPI.Models.User
{
    public class GetUserDto : BaseUserDto
    {
        public Guid Id { get; set; }
    }
}
