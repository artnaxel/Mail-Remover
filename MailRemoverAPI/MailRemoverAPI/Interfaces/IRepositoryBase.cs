using MailRemoverAPI.Entities;

namespace MailRemoverAPI.Interfaces
{
    public interface IRepositoryBase<T> where T : Entity
    {
        public Task<List<T>> GetAllAsync();

        public Task<T?> GetByIdAsync(Guid Id);

    }
}
