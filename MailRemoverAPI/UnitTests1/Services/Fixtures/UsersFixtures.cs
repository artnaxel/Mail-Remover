using MailRemoverAPI.Entities;

namespace UnitTests.Fixtures
{
    public static class UsersFixtures
    {
        public static List<User> GetUserControllerTests() => new()
        {
            new User()
            {
                FirstName = "Lina",
                LastName = "Lianite",
                Password = "bxYHi468",
                Emails = new List<Email>()
                {
                new Email
                {
                    Type = MailRemoverAPI.Enums.EmailType.Gmail,
                    Id = new Guid("c8d69fc2-45d6-4112-b853-6f6c5cd7c498"),
                    Address = "linalina@gmail.com",
                    Token = "a08885be-89da",
                    UserId = new Guid("487d101f-ab59-42f2-839e-039b680667cb")
                    }
                }
            },
            new User()
            {
                FirstName = "Lukas",
                LastName = "Lukaitis",
                Password = "@G3gng9t6XBe",
                Emails = new List<Email>()
                {
                new Email
                {
                    Type = MailRemoverAPI.Enums.EmailType.Gmail,
                    Id = new Guid("c8d69fc2-45d6-4112-b853-6f6c5cd7c498"),
                    Address = "lukiukasss@outlook.com",
                    Token = "a08885be-89da",
                    UserId = new Guid("487d101f-ab59-42f2-839e-039b680667cb")
                    }
                }
            },
            new User()
            {
                FirstName = "Tomas",
                LastName = "Tomaitis",
                Password = "@G3gng9t6XBe",
                Emails = new List<Email>()
                {
                new Email
                {
                    Type = MailRemoverAPI.Enums.EmailType.Gmail,
                    Id = new Guid("c8d69fc2-45d6-4112-b853-6f6c5cd7c498"),
                    Address = "lukasLukaitis@gmail.com",
                    Token = "a08885be-89da",
                    UserId = new Guid("487d101f-ab59-42f2-839e-039b680667cb")
                    }
                }
            },
        };
    }
}