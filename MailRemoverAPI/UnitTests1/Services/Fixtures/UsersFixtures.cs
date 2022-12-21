using MailRemoverAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Services.Fixtures
{
    public class UsersFixtures
    {
        public static List<User> GetUserControllerTests() => new()
        {
            new User()
            {
                Id = new Guid("c8d69fc2-45d6-4112-b853-6f6c5cd7c498"),
                FirstName = "Lina",
                LastName = "Linaite",
                Password = "bxYHi468",
                UserEmail = "lina@gmail.com",
            }
        };
    }
}
