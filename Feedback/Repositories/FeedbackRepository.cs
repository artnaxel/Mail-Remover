using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using M = Feedback.Models;
using Feedback.DB;

namespace Feedback.Repositories
{
    public class FeedbackRepository : IEntityRepository<M.Feedback>
    {
        private FeedbackDbContext dbContext;

        public FeedbackRepository(FeedbackDbContext ctx)
        {
            dbContext = ctx;
        }

        public async Task<int> GetCount() {
            await Task.Delay(1);
            return dbContext.Feedback.Count();
        }

        public async Task<IEnumerable<M.Feedback>> GetAll() {
            await Task.Delay(1);
            return dbContext.Feedback;
        }

        public async Task<IEnumerable<M.Feedback>> GetBy(Predicate<M.Feedback> pred) {
            await Task.Delay(1);
            return dbContext.Feedback
                .Where((f) => pred(f));
        }

        public async Task<M.Feedback?> GetById(Guid id)
            => (await this.GetBy((f) => f.Id.Equals(id))).Last();

        public async Task<Guid> Insert(M.Feedback feedback) {
            dbContext.Feedback.Add(feedback);
            dbContext.SaveChanges();

            return feedback.Id;
        }

        public async Task UpdateByGuid(Guid guid, Func<M.Feedback, M.Feedback> func) {
            dbContext.Feedback
                .Where((f) => f.Id == guid)
                .Select(func)
                .AsEnumerable();
            
            dbContext.SaveChanges();
        }
    }
}