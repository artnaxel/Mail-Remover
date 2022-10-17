using Microsoft.EntityFrameworkCore;
using MailRemoverAPI.Enums;

namespace MailRemoverAPI.Entities
{
    public class MailRemoverDbContext : DbContext
    {
        public MailRemoverDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Email> Emails { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Guid g1 = Guid.NewGuid();
            Guid g2 = Guid.NewGuid();
            Guid g3 = Guid.NewGuid();
            Guid g4 = Guid.NewGuid();

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = g1,
                    FirstName = "Tomas",
                    LastName = "Sinkevičius",
                    Password = "RjEUW1R58r"
                },
                new User 
                { 
                    Id = g2, 
                    FirstName = "Greta", 
                    LastName = "Virpšaitė",
                    Password = "@G3gng9t6XBe"
                },
                new User
                {
                    Id = g3,
                    FirstName = "Austėja",
                    LastName = "Naujokaitė",
                    Password = "3Gcoj6!Z1bnc"
                },
                new User
                {
                    Id = g4,
                    FirstName= "Benas",
                    LastName = "Skripkiūnas",
                    Password = "*Y4!3l710POq"
                }
                );


            modelBuilder.Entity<Email>().HasData(
                new Email
                {
                    Id = Guid.NewGuid(),
                    Type = EmailType.Gmail,
                    UserId = g1,
                    Token = "b07f85be-45da"
                },
                new Email
                {
                    Id = Guid.NewGuid(),
                    Type = EmailType.Gmail,
                    UserId = g1,
                    Token = "a08885be-89da"
                }, 
                new Email
                {
                    Id = Guid.NewGuid(),
                    Type = EmailType.Gmail,
                    UserId = g2,
                    Token = "b07f96be-45da"
                },
                new Email
                {
                    Id = Guid.NewGuid(),
                    Type = EmailType.Gmail,
                    UserId = g3,
                    Token = "b07f45be-45da"
                },
                new Email
                {
                    Id = Guid.NewGuid(),
                    Type = EmailType.Gmail,
                    UserId = g4,
                    Token = "b07f75be-45da"
                }
                );
        }
    }
}
