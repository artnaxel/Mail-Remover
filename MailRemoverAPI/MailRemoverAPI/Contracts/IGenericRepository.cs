using MailRemoverAPI.Entities;

namespace MailRemoverAPI.Contracts
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetAsync(Guid? id);
        Task<List<T>> GetAllAsync();
        Task<T> AddAsync(T entity);
        Task DeleteAsync(Guid id);
        Task UpdateAsync(T entity);
        Task<bool> Exists(Guid id);
    }
}
