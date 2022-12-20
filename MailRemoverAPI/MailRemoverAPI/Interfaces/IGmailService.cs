using MailRemoverAPI.Models.Gmail;
using System.Drawing;

namespace MailRemoverAPI.Interfaces
{
    public interface IGmailService
    {
        public Task<string> Auth(Guid id);

        public Task<GmailDto?> PostAccessCode(string code, string state);

        public Task RefreshAccessToken(Guid id);

        public Task<Profile> GetProfile(Guid id);

        public Task<List<MessageDto>> GetProfileMessagesAsync(Guid id);

        public Task<Dictionary<string, int>> CalculateMemoryConsumption(Guid id);

        public Task<int> BatchDeleteMessagesFromEmailAddress(Guid id, string emailFrom);
    }
}
