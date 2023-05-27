using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using M = Feedback.Models;

namespace Feedback.Repositories
{
    // TODO
    public interface IFeedbackRepository
    {
        public Task<IEnumerable<M.Feedback>> GetFeedbackById(Guid id);
        public Task InsertFeedback(M.Feedback feedback);

        public Task UpdateFeedbackByGuid(
            Guid guid,
            Func<M.Feedback, M.Feedback> func
        );
   }
}