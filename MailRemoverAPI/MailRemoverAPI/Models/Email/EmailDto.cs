using MailRemoverAPI.Enums;

namespace MailRemoverAPI.Models.Email
{
    public class EmailDto
    {
        public EmailType Type { get; set; }
        public string Address { get; set; }
        
    }
}
