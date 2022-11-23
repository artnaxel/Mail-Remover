namespace MailRemoverAPI.Models.Gmail
{
    public class RefreshedAccessData
    {
        public string access_token { get; set; }

        public int expires_in { get; set; }

        public string token_type { get; set; }
    }
}
