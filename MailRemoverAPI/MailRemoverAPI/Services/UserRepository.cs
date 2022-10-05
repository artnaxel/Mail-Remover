using MailRemoverAPI.Entities;
using MailRemoverAPI.Interfaces;

namespace MailRemoverAPI.Services
{
    public class UserRepository : IUserRepository
    {
        private IJSONFileReaderService _jsonFileReaderService;

        public UserRepository(IJSONFileReaderService jsonFileReaderService)
        {
            _jsonFileReaderService = jsonFileReaderService;
        }

        public async Task<List<User>> GetAllAsync()
        {
            var users = await _jsonFileReaderService.ReadAll<User>();

            if(users is null)
            {
                return new List<User>();
            }

            return users;
        }

        public async Task<User?> GetByIdAsync(Guid Id)
        {
            
            var users = await _jsonFileReaderService.ReadAll<User>();

            var user = users.Where(x => x.Id == Id).FirstOrDefault();

            return user;
        }
    }
}
