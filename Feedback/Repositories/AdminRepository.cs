namespace Feedback.Repositories;

using Microsoft.EntityFrameworkCore;

using M = Feedback.Models;
using Feedback.DB;

public class AdminRepository : IEntityRepository<M.Admin> {
    private FeedbackDbContext _dbCtx { get; init; }
    private AdminRepository() {}
    public AdminRepository(FeedbackDbContext repo) { _dbCtx = repo; }
    
    public async Task<int> GetCount() =>
        _dbCtx.Admin.Count();
    
    public async Task<IEnumerable<M.Admin>> GetAll() =>
        _dbCtx.Admin;
    
    public async Task<M.Admin?> GetById(Guid id) =>
        ( await this.GetBy((a) => a.Id.Equals(id)) ).Last();

    public async Task<IEnumerable<M.Admin>> GetBy(Predicate<M.Admin> pred) =>
        _dbCtx.Admin.Where((a) => pred(a));
    
    public async Task Insert(M.Admin admin)
    {
        _dbCtx.Admin.Add(admin);
        _dbCtx.SaveChanges();
    }

    public async Task UpdateByGuid(Guid id, Func<M.Admin, M.Admin> func)
    {
        _dbCtx.Admin.Where((a) => a.Id.Equals(id)).Select(func).AsEnumerable();
        _dbCtx.SaveChanges();
    }
}