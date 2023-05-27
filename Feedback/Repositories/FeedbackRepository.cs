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
        private IList<M.Feedback> _feedback = new List<M.Feedback>();
        private FeedbackDbContext dbContext;

        // Just imagine we have a DB
        // public FeedbackRepository(DbContext dbContext) {}
        public FeedbackRepository(FeedbackDbContext ctx)
        {
            dbContext = ctx;
        }

        public async Task<IEnumerable<M.Feedback>> GetAllFeedback() {
            await Task.Delay(1);
            return _feedback;
        }

        public async Task<IEnumerable<M.Feedback>> GetFeedbackBy(Predicate<M.Feedback> pred) {
            await Task.Delay(1);
            return _feedback 
                .Where((f) => pred(f));
        }

        public async Task<IEnumerable<M.Feedback>> GetFeedbackById(Guid id)
            => await this.GetFeedbackBy((f) => f.Id.Equals(id));

        public async Task InsertFeedback(M.Feedback feedback) {
            await Task.Delay(1);
            _feedback.Add(feedback);
        }

        public async Task UpdateFeedbackByGuid(Guid guid, Func<M.Feedback, M.Feedback> func) {
            await Task.Delay(1);
            _feedback
                .Where((f) => f.Id == guid)
                .Select(func);
        }
    }
}