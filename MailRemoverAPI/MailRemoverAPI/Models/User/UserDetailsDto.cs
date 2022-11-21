using MailRemoverAPI.Models.Email;

namespace MailRemoverAPI.Models.User
{
    public class UserDetailsDto : BaseUserDto
    {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public Guid UserId { get; set; }

            public List<EmailDto> Emails { get; set; }
        
    }
}
