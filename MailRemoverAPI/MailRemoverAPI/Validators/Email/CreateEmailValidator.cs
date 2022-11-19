using System.Text.RegularExpressions;

namespace MailRemoverAPI.Validators.Email
{
    public class CreateEmailValidator
    {
        public static void EmailValidator(Entities.Email email)
        {
            if(!Regex.IsMatch(email.Address, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"))
            {
                throw new Exception("Email address is wrong");
            }
        }
    }
}
