using MailRemoverAPI.Entities;
using MailRemoverAPI.Interfaces;
using MailRemoverAPI.Validators.Email;
using Microsoft.AspNetCore.Mvc;

namespace MailRemoverAPI.Controllers
{
    public class GmailsController : BaseController
    {
        public IGmailService _gmailService;

        public IGmailRepository _repository;

        public GmailsController(IGmailService gmailService, IGmailRepository repository)
        {
            _gmailService = gmailService;
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _repository.GetAllAsync();

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetById([FromQuery] Guid Id)
        {
            var result = await _repository.GetByIdAsync(Id);

            if (result is null)
            {
                return BadRequest();
            }

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> RefreshAccessToken([FromQuery] Guid id)
        {
            await _gmailService.RefreshAccessToken(id);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetProfile([FromQuery] Guid Id)
        {
            var result = await _gmailService.GetProfile(Id);

            if (result is null)
            {
                return BadRequest();
            }

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetProfileMessages([FromQuery] Guid Id)
        {
            var result = await _gmailService.GetProfileMessagesAsync(Id);

            if (result is null)
            {
                return BadRequest();
            }

            return Ok(result);
        }
    }
}
