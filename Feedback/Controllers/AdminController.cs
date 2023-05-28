namespace Feedback.Controllers;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;

using M = Feedback.Models;
using Feedback.Repositories;

[ApiController]
[Route("admin")]
public class AdminController : Controller {

    private IEntityRepository<M.Admin> _adminRepo { get; init; }
    private IEntityRepository<M.Feedback> _feedbackRepo { get; init; }
    // private ILogger<FeedbackController> _logger { get; init; }

    public AdminController(
        IEntityRepository<M.Admin> adminRepo,
        IEntityRepository<M.Feedback> feedbackRepo
    ) {
        _adminRepo = adminRepo;
        _feedbackRepo = feedbackRepo;
    }

    [HttpGet]
    public async Task<IEnumerable<M.Admin>> Get() {
        return await _adminRepo.GetAll();
    }

    [HttpGet("count")]
    public async Task<int> Count() => await _adminRepo.GetCount();

    /// <returns> returns newly assigned id </returns>
    [HttpPost("create")]
    public async Task<Guid> Insert(string name, string role) {
        M.Admin newAdmin = new() { Name = name, Role = role};
        await _adminRepo
            .Insert(newAdmin);
        
        return newAdmin.Id;
    }

    [HttpPut("assign-feedback")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task AssignFeedback(Guid adminId, Guid feedbackId)
    {
        var feedback = await _feedbackRepo.GetById(feedbackId);
        var admin = await _adminRepo.GetById(adminId);

        if (feedback is null)
            NotFound();
            // throw new HttpException(404, $"Bad Request. Feedback of id: {feedbackId} not found");

        if (admin is null)
            NotFound();
            // throw new HttpException(404, $"Bad Request. Admin of id: {adminId} not found");
 
        await _adminRepo
            .UpdateByGuid(adminId, (a) => { 
                a.Feedbacks.Add(feedback);
                return a;
            });

        Ok();
    }
    // public async Task AssignTicket() => throw new NotImplementedException();

}

