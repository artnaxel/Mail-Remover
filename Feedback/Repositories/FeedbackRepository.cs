using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using M = Feedback.Models;
using Feedback.DB;

namespace Feedback.Repositories
{
    public class FeedbackRepository : IFeedbackRepository
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

        public async Task<IEnumerable<M.Feedback>> GetAllFeedback() {
            await Task.Delay(1);
            return dbContext.Feedback;
        }

        public async Task<IEnumerable<M.Feedback>> GetFeedbackBy(Predicate<M.Feedback> pred) {
            await Task.Delay(1);
            return dbContext.Feedback
                .Where((f) => pred(f));
        }

        public async Task<IEnumerable<M.Feedback>> GetFeedbackById(Guid id)
            => await this.GetFeedbackBy((f) => f.Id.Equals(id));

        public async Task InsertFeedback(M.Feedback feedback) {
            await Task.Delay(1);
            dbContext.Feedback.Add(feedback);
        }

        public async Task UpdateFeedbackByGuid(Guid guid, Func<M.Feedback, M.Feedback> func) {
            await Task.Delay(1);
            dbContext.Feedback
                .Where((f) => f.Id == guid)
                .Select(func);
        }
    }
}