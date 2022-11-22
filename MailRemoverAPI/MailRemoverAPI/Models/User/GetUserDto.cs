using MailRemoverAPI.Models.Gmail;

namespace MailRemoverAPI.Models.User
{
    public class GetUserDto : BaseUserDto
    {
        public Guid Id { get; set; }

        public List<GmailDto> Gmails { get; set; }
    }
}
