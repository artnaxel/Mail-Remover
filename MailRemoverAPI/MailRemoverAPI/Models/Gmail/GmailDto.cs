namespace MailRemoverAPI.Models.Gmail
{
    public class GmailDto
    {
        public string AccessToken { get; set; }

        public string RefreshToken { get; set; }

        public DateTime Expires { get; set; }

        public Guid UserId { get; set; }

        public string Address { get; set; }
    }
}
