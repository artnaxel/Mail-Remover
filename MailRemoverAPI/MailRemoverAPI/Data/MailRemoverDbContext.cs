using Microsoft.EntityFrameworkCore;
using MailRemoverAPI.Enums;
using MailRemoverAPI.Entities;

namespace MailRemoverAPI.Data
{
    public class MailRemoverDbContext : DbContext
    {
        public MailRemoverDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Email> Emails { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Gmail> Gmails { get; set; }

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
                    UserEmail = "tomas.sinkevicius@gmail.com",
                    FirstName = "Tomas",
                    LastName = "Sinkevičius",
                    Password = "RjEUW1R58r"
                },
                new User
                {
                    Id = g2,
                    UserEmail = "greta.virpsaite@gmail.com",
                    FirstName = "Greta",
                    LastName = "Virpšaitė",
                    Password = "@G3gng9t6XBe"
                },
                new User
                {
                    Id = g3,
                    UserEmail = "austeja.naujokaite@gmail.com",
                    FirstName = "Austėja",
                    LastName = "Naujokaitė",
                    Password = "3Gcoj6!Z1bnc"
                },
                new User
                {
                    Id = g4,
                    UserEmail = "benas.skripkunas@gmail.com",
                    FirstName = "Benas",
                    LastName = "Skripkiūnas",
                    Password = "*Y4!3l710POq"
                }
                );


            modelBuilder.Entity<Email>().HasData(
                new Email
                {
                    Id = Guid.NewGuid(),
                    Type = EmailType.Gmail,
                    Address = "1234user@gmail.com",
                    UserId = g1,
                    Token = "b07f85be-45da"
                },
                new Email
                {
                    Id = Guid.NewGuid(),
                    Type = EmailType.Gmail,
                    Address = "1234wre2ruser@gmail.com",
                    UserId = g1,
                    Token = "a08885be-89da"
                },
                new Email
                {
                    Id = Guid.NewGuid(),
                    Type = EmailType.Gmail,
                    Address = "rsdfe2ruser@gmail.com",
                    UserId = g2,
                    Token = "b07f96be-45da"
                },
                new Email
                {
                    Id = Guid.NewGuid(),
                    Type = EmailType.Gmail,
                    Address = "lunasuo@gmail.com",
                    UserId = g3,
                    Token = "b07f45be-45da"
                },
                new Email
                {
                    Id = Guid.NewGuid(),
                    Type = EmailType.Gmail,
                    Address = "lapesuo@gmail.com",
                    UserId = g4,
                    Token = "b07f75be-45da"
                }
                );
        }
    }
}
