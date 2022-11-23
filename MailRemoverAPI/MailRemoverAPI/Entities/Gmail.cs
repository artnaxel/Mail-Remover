using MailRemoverAPI.Events;
using System.ComponentModel.DataAnnotations;
using static MailRemoverAPI.Events.Delegate;

namespace MailRemoverAPI.Entities
{
    public class Gmail : Entity
    {
        public event AccessTokenExpiredEventHandler<Gmail, AccessTokenExpiredEventHandlerArgs> AccessTokenExpired;


        [StringLength(320)]
        public string Address { get; set; }

        private string accessToken;

        public string AccessToken
        {
            get
            {
                if (Expires < DateTime.Now && AccessTokenExpired is not null)
                {
                    AccessTokenExpired(this, new() { Id = this.Id });
                    return null;
                }
                return accessToken;
            }
            set
            {
                accessToken = value;
            }
        }
        public string RefreshToken { get; set; }

        public DateTime Expires { get; set; }

        public Guid UserId { get; set; }

        public User User { get; set; }
    }
}
