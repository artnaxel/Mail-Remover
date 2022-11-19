using MailRemoverAPI.Entities;

namespace MailRemoverAPI.Services
{
    public class PasswordServices
    {
        public static string hashPassword(string Password)
        {
            return BCrypt.Net.BCrypt.HashPassword(Password);

        }

        public static bool CheckPassword(User u, string password)
        { 
            return BCrypt.Net.BCrypt.Verify(password, u.Password);
        }

    }
}
