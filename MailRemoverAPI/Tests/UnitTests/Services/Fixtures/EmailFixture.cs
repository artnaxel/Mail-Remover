using MailRemoverAPI.Entities;
using MailRemoverAPI.Enums;

namespace UnitTests.Services.Fixtures
{
    public class EmailFixture
    {
        public static List<Email> GetEmailControllerTests() => new()
        {
            new Email
            {
                Type = MailRemoverAPI.Enums.EmailType.Gmail,
                Id = new Guid("c8d69fc2-45d6-4112-b853-6f000cd7c498"),
                Address = "lukiukasss@outlook.com",
                Token = "a08885be-89da",
                UserId = new Guid("487d101f-ab59-42f2-839e-000b680667cb")
            },
            new Email
            {
                Type = MailRemoverAPI.Enums.EmailType.Gmail,
                Id = new Guid("c8d69fc2-45d6-4112-b853-6f6c0007c498"),
                Address = "lukiukasss@outlook.com",
                Token = "a08885be-89da",
                UserId = new Guid("487d101f-ab59-42f2-839e-0001680667cb")
            },
            new Email
            {
                Type = MailRemoverAPI.Enums.EmailType.Gmail,
                Id = new Guid("c8d69fc2-45d6-4112-b853-6f6c5000c498"),
                Address = "lukiukasss@outlook.com",
                Token = "a08885be-89da",
                UserId = new Guid("487d101f-ab59-42f2-000e-039b680667cb")
            },
        };
    }
}
