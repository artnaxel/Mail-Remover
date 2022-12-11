using MailRemoverAPI.Models.Email;

namespace MailRemoverAPI.Models.User
{
    public class UserDetailsDto : BaseUserDto
    {
        public Guid UserId { get; set; }
        public List<EmailDto> Emails { get; set; }
        
    }
}
