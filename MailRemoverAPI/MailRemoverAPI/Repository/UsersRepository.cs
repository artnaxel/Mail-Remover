using MailRemoverAPI.Contracts;
using MailRemoverAPI.Data;
using MailRemoverAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace MailRemoverAPI.Repository
{
    public class UsersRepository : GenericRepository<User>, IUsersRepository
    {
        private readonly MailRemoverDbContext _context;

        public UsersRepository(MailRemoverDbContext context) : base(context)
        {
            this._context = context;
        }

        public async Task<User> GetDetails(Guid id)
        {
            return await _context.Users.Include(q => q.Emails).FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task<User> AddAsync(User user)
        {
            user.Id = Guid.NewGuid();
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

    }
}
