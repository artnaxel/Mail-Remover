using MailRemoverAPI.Entities;

namespace MailRemoverAPI.Interfaces
{
    public interface IEmailRepository : IRepositoryBase<Email>
    {
        public Task<double?> ToTonns(int Mb);

        public Task<long?> ToGrams(int Mb);

        public short Co2toKg(int Mb);
    }
}
