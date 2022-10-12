using System;

namespace MailRemoverAPI.Entities
{
    public class User : Entity, IComparable<User>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Password Password { get; set; }

        public int CompareTo(User? other)
        {
            return LastName.CompareTo(other.LastName);
        }
    }
}
