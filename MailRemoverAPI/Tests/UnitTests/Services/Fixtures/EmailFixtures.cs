using MailRemoverAPI.Entities;
using MailRemoverAPI.Enums;

namespace UnitTests.Services.Fixtures
{
    public class EmailFixtures
    {
        public static List<Email> GetEmailControllerTests() => new()
        {
            new Email
            {
                Id = new Guid("c8d69fc2-45d6-4112-b853-6f6c5cd7c5"),
                Type = EmailType.Gmail,
                Address = "1234user@gmail.com",
                UserId =  new Guid("c8d69fc2-45d6-4112-bhj7-6f6cbg57c498"),
                Token = "b07f85be-45da"
            },
            new Email
            {
                Id = new Guid("c8d69fc2-45d6-4112-b853-6f6c5cd77868"),
                Type = EmailType.Gmail,
                Address = "1234wre2ruser@gmail.com",
                UserId =  new Guid("c8d69fc2-45d6-4112-b853-6jkh5cd7c498"),
                Token = "a08885be-89da"
            },
            new Email
            {
                Id = new Guid("c8d6hjki-45d6-4112-b853-6f6c5cd7c498"),
                Type = EmailType.Gmail,
                Address = "rsdfe2ruser@gmail.com",
                UserId =  new Guid("c8d69kl4-l5d6-4112-b853-6f6c5cd7c498"),
                Token = "b07f96be-45da"
            }
        };
    }
}
