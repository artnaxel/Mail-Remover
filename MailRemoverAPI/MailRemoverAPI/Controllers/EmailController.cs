using MailRemoverAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MailRemoverAPI.Controllers
{
    public class EmailController : BaseController
    {
        private IEmailRepository _emailRepository;

        public EmailController(IEmailRepository emailRepository)
        {
            _emailRepository = emailRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _emailRepository.GetAllAsync();
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetById([FromQuery] Guid Id)
        {
            var result = await _emailRepository.GetByIdAsync(Id);

            if (result is null)
            {
                return BadRequest();
            }

            return Ok(result);
        }
    }
}
