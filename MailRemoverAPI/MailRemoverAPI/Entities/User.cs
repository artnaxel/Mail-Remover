using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using MailRemoverAPI.Services;

namespace MailRemoverAPI.Entities
{
    public class User : Entity, IComparable<User>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        private string _password;
        public string Password
        {
            get { return this._password; }
            set
            {
                _password = PasswordServices.hashPassword(value);
            }
        }


        public virtual IList<Email>? Emails { get; set; }

        public int CompareTo(User? other)
        {
            return LastName.CompareTo(other.LastName);
        }

        public bool CheckPassword(string Password)
        {
            return PasswordServices.CheckPassword(this, Password);
        }
    }
}