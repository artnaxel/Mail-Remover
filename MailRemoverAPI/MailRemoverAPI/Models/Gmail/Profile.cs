namespace MailRemoverAPI.Models.Gmail
{
    public class Profile
    {
        public string EmailAddress { get; set; }

        public int MessagesTotal { get; set; }

        public int ThreadsTotal { get; set; }

        public string HistoryId { get; set; }
    }
}
