using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using M = Feedback.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.InMemory;

namespace Feedback.DB
{
    public class FeedbackDbContext : DbContext
    {
        public DbSet<M.Feedback> Feedback { get; private set; }

        public FeedbackDbContext(DbContextOptions opts) : base(opts) {}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase();
        }

        protected override void OnModelCreating(ModelBuilder builder) {
            // TODO: figure feedback insertion
            builder
                .Entity<M.Feedback>()
                .HasMany((f) => f.Attachments);

            base.OnModelCreating(builder);
        }

        private void OnEntityTracked(object sender, EntityTrackedEventArgs e)
        {
            if (!e.FromQuery && e.Entry.State == EntityState.Added && e.Entry.Entity is M.Entity entity)
            {
                entity.CreatedOn = DateTime.UtcNow;
            }
        }

        private void OnEntityStateChanged(object sender, EntityStateChangedEventArgs e)
        {
            if (e.NewState == EntityState.Modified && e.Entry.Entity is M.Entity entity)
            {
                entity.ModifiedOn = DateTime.UtcNow;
            }
        }
    }
}