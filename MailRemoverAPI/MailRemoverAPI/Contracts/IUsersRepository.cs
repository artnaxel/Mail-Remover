using MailRemoverAPI.Entities;

namespace MailRemoverAPI.Contracts
{
        public interface IUsersRepository : IGenericRepository<User>
        {
            Task<User> GetDetails(Guid id);
        }   
}
