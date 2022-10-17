using Microsoft.EntityFrameworkCore;

namespace MailRemoverAPI.Entities
{
    public class MailRemoverDbContext : DbContext
    {
        public MailRemoverDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Email> Emails { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
