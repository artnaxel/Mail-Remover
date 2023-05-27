namespace Feedback.Controllers;

using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

using M = Feedback.Models;
using Feedback.Repositories;

[ApiController]
[Route("feedback")]
public class FeedbackController : Controller {

    private IFeedbackRepository _repo { get; init; }
    // private ILogger<FeedbackController> _logger { get; init; }

    public FeedbackController(IFeedbackRepository repo)
    {
        _repo = repo;
    }

    [HttpGet]
    public async Task<IEnumerable<M.Feedback>> Get() {
        // _repo.GetFeedbackById
        return await _repo.GetAllFeedback();
    }

    [HttpGet("/count")]
    public async Task<int> Count() => await _repo.GetCount();
}