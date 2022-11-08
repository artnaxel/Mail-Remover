namespace MailRemoverAPI.Models.Gmail
{
    public class Gmail
    {
        public string MsgID { get; set; }

        public string From { get; set; }

        public string To { get; set; }

        public string Body { get; set; }

        public DateTime MailDateTime { get; set; }

        public List<string> Attachments { get; set; }


    }
}
