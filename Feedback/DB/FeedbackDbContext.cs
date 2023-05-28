using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using M = Feedback.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Feedback.DB
{
    public class FeedbackDbContext : DbContext
    {
        public DbSet<M.Feedback> Feedback { get; private set; }
        public DbSet<M.Admin> Admin { get; private set; }

        public FeedbackDbContext(DbContextOptions opts) : base(opts) {}

        protected override void OnModelCreating(ModelBuilder builder) {
            // builder
            //     .Entity<M.Feedback>()
            //     .HasKey((f) => f.Id);
            
            builder
                .Entity<M.Feedback>()
                .HasMany((f) => f.Attachments);
            
            builder
                .Entity<M.Admin>()
                .HasMany((a) => a.Tickets);
            
            builder
                .Entity<M.Admin>()
                .HasMany((a) => a.Feedbacks);

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