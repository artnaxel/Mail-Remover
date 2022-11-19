using MailRemoverAPI.Entities;
using MailRemoverAPI.Interfaces;
using MailRemoverAPI.Validators.Email;
using MailRemoverAPI.Services;
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
            var sortedResult = result.OrderBy(email => email.Type);
            return Ok(sortedResult);
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

        [HttpGet]
        public async Task<IActionResult> GetEmision([FromQuery] int mb)
        {
            var result = await _emailRepository.ToGrams(mb);

            if (result is null)
            {
                return BadRequest();
            }

            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Email email)
        {
            CreateEmailValidator.EmailValidator(email);
            return Ok($"{1} {2}");
        }
    }
}
