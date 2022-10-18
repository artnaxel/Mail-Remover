using System.ComponentModel.DataAnnotations.Schema;

namespace MailRemoverAPI.Entities
{
    public class User : Entity, IComparable<User>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Password { get; set; }


        public virtual IList<Email>? Emails { get; set; }
    }
}