using MailRemoverAPI.Enums;

namespace MailRemoverAPI.Entities
{
    public class Email : Entity
    {
        public EmailType Type { get; set; }

        public User User { get; set; }

        public string Token { get; set; }
    }
}
