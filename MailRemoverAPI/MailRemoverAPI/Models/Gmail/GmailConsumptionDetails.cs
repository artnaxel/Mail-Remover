namespace MailRemoverAPI.Models.Gmail
{
    public class GmailConsumptionDetails
    {
        public GmailConsumptionDetails()
        {
            gmailEmailMemoryConsumptionPairs = new();
        }
        public List<GmailEmailMemoryConsumptionPair> gmailEmailMemoryConsumptionPairs { get; set; }

        public double Co2Emissions { get; set; } = 0;
    }
}
