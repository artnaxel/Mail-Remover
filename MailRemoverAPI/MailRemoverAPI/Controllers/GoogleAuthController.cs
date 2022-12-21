using MailRemoverAPI.Interfaces;
using MailRemoverAPI.Models.Gmail;
using MailRemoverAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace MailRemoverAPI.Controllers
{
    public class GoogleAuthController : BaseController
    {
        IGmailService _gmailService;

        public GoogleAuthController(IGmailService gmailService)
        {
            _gmailService = gmailService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(Guid user_id)
        {
            var url = _gmailService.Auth(user_id);
            return Ok(url);
        }

        [HttpGet]
        public async Task<IActionResult> Code(string code, string state)
        {
            var response = await _gmailService.PostAccessCode(code, state);
            return Redirect("http://localhost:3000");
        }
    }
}
