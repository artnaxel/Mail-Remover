using MailRemoverAPI.Entities;
using MailRemoverAPI.Interfaces;

namespace MailRemoverAPI.Services
{
    public class EmailRepository : IEmailRepository
    {
        private IJSONFileReaderService _jsonFileReaderService;

        public EmailRepository(IJSONFileReaderService jsonFileReaderService)
        {
            _jsonFileReaderService = jsonFileReaderService;
        }

        public async Task<List<Email>> GetAllAsync()
        {
            var emails = await _jsonFileReaderService.ReadAll<Email>();

            if (emails is null)
            {
                return new List<Email>();
            }

            return emails;
        }

        public async Task<Email?> GetByIdAsync(Guid Id)
        {

            var emails = await _jsonFileReaderService.ReadAll<Email>();

            var email = emails.Where(x => x.Id == Id).FirstOrDefault();

            return email;
        }

        public short Co2toKg(int Mb)
        {
            short calculated = (short)(Mb * 0.019);
            return calculated;
        }

        public async Task<long?> ToGrams(int Mb)
        {
            return (long)(this.Co2toKg(Mb) * 1000000);
        }

        public async Task<double?> ToTonns(int Mb)
        {
            return (double)(this.Co2toKg(Mb) / 1000000);
        }

    }
}