using MailRemoverAPI.Entities;
using MailRemoverAPI.Models.Gmail;

namespace MailRemoverAPI.Interfaces
{
    public interface IGmailRepository : IRepositoryBase<Gmail>
    {
        public Task<Guid> CreateAsync(GmailDto gmail);


    }
}