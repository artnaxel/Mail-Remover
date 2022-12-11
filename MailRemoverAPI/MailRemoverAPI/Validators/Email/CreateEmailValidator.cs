using System.Text.RegularExpressions;

namespace MailRemoverAPI.Validators.Email
{
    public class CreateEmailValidator
    {
        public static bool IsEmailValid(string email)
        {
            if (!Regex.IsMatch(email, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"))
            {
                return false;
            } 
            return true;
        }

        public static string UserEmailValidator(string email)
        {
            if (!IsEmailValid(email)) 
            {
                throw new ArgumentException("Email is not valid");
            }
            return email;
        }
        
        public static void EmailValidator(Entities.Email email)
        {
            if(!IsEmailValid(email.Address))
            {
                throw new Exception("Email address is wrong");
            }
        }
    }
}
