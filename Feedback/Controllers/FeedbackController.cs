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

    // private FeedbackController() {}

    // public FeedbackController(ILogger<FeedbackController> illoger, FeedbackRepository repo) => new FeedbackController() {
    //     _logger = 
    // };

    // public FeedbackRepository(FeedbackDbContext ctx) {

    // }

    [HttpGet]
    public IEnumerable<M.Feedback> GetId() {
        throw new NotImplementedException();
    }
}