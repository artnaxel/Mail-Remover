using MailRemoverAPI.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace MailRemoverAPI.Entities
{
    public class Email : Entity
    {
        public EmailType Type {  get; set; }

        public string Address { get; set; }

        public string Token { get; set; }

        [ForeignKey(nameof(UserId))]
        public Guid UserId { get; set; }
        public User User { get; set; }
        
    }
}
