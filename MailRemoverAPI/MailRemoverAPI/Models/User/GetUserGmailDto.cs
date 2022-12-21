using MailRemoverAPI.Models.Gmail;

namespace MailRemoverAPI.Models.User
{
    public class GetUserGmailDto : BaseUserDto
    {
        public List<GmailDto> Gmails { get; set; }
    }
}
