using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using MailRemoverAPI.Services;
using MailRemoverAPI.Validators.Email;

namespace MailRemoverAPI.Entities
{
    public class User : Entity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string _userEmail;
        public string UserEmail 
        { 
            get { return this._userEmail; }
            set
            {
                _userEmail = CreateEmailValidator.UserEmailValidator(value);
            }
        }

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

        private Lazy<List<Gmail>> _gmails;
        public List<Gmail> Gmails {
            get => _gmails?.Value;
            set => _gmails = new Lazy<List<Gmail>>(() => value);
        }
    }
}