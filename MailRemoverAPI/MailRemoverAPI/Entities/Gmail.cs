using System.ComponentModel.DataAnnotations;

namespace MailRemoverAPI.Entities
{
    public class Gmail : Entity
    {
        [StringLength(320)]
        public string Address { get; set; }

        public string AccessToken { get; set; }

        public string RefreshToken { get; set; }

        public DateTime Expires { get; set; }

        public Guid UserId { get; set; }

        public User User { get; set; }
    }
}
