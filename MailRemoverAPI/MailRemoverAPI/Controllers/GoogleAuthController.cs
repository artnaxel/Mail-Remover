using MailRemoverAPI.Interfaces;
using MailRemoverAPI.Models.Gmail;
using MailRemoverAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace MailRemoverAPI.Controllers
{
    public class GoogleAuthController : BaseController
    {
        GmailService _gmailService;

        public GoogleAuthController(GmailService gmailService)
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
        public async Task<IActionResult> Code(string code)
        {
            var response = await _gmailService.PostAccessCode(code);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Token([FromBody] AccessData accessData)
        {
            _gmailService.AccessTokens.Add(accessData);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAccessData()
        {
            return Ok(_gmailService.AccessTokens);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCodes()
        {
            return Ok(_gmailService.Codes);
        }
    }
}
