using MailRemoverAPI.Models.Gmail;

namespace MailRemoverAPI.Interfaces
{
    public interface IGmailService
    {
        public Task<string> Auth(Guid id);

        public Task<GmailDto?> PostAccessCode(string code, string state);

        public Task RefreshAccessToken(Guid id);
    }
}
