using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using M = Feedback.Models;

namespace Feedback.Repositories
{
    public interface IEntityRepository<TEntity>
    {
        public Task<int> GetCount();
        public Task<IEnumerable<TEntity>> GetAll();
        public Task<TEntity?> GetById(Guid id);
        public Task Insert(TEntity feedback);

        public Task UpdateByGuid(
            Guid guid,
            Func<TEntity, TEntity> func
        );
   }
}