namespace MailRemoverAPI.Entities
{
    public class User : Entity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public List<Email> Emails { get; set; }
    }
}
