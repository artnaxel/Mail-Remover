namespace MailRemoverAPI.Models.Gmail
{
    public class MessagesListDto
    {
        public List<PartialMessageDto> Messages { get; set; }

        public string NextPageToken { get; set; }

        public int ResultSizeEstimate { get; set; }
    }
}