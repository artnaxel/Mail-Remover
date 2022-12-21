namespace MailRemoverAPI.Models.Gmail
{
    public class MessageDto : PartialMessageDto
    {
        public List<string> LabelIds { get; set; }

        public string Snippet { get; set; }

        public string HistoryId { get; set; }

        public string InternalDate { get; set; }

        public MessagePayload Payload { get; set; }

        // Estimated size in bytes of the message
        public int SizeEstimate { get; set; } 

        public string Raw { get; set; }
    }
}
