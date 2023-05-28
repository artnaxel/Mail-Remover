namespace Feedback.Controllers;

using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

using M = Feedback.Models;
using Feedback.Repositories;

[ApiController]
[Route("feedback")]
public class FeedbackController : Controller {

    private IEntityRepository<M.Feedback> _repo { get; init; }
    // private ILogger<FeedbackController> _logger { get; init; }

    public FeedbackController(IEntityRepository<M.Feedback> repo)
    {
        _repo = repo;
    }

    [HttpGet]
    public async Task<IEnumerable<M.Feedback>> Get() {
        return await _repo.GetAll();
    }

    [HttpGet("count")]
    public async Task<int> Count() => await _repo.GetCount();

    [HttpPost("create")]
    public async Task Insert([FromBody] M.Feedback feedback) => 
        await _repo
            .Insert(feedback);
}