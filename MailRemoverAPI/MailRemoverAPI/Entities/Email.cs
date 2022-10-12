using MailRemoverAPI.Enums;

namespace MailRemoverAPI.Entities
{
    public class Email : Entity
    {
        public EmailType Type {  get; set; }

        public string Address { get; set; }

        public Guid UserId { get; set; }

        public string Token { get; set; }
    }
}
