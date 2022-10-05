using MailRemoverAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MailRemoverAPI.Controllers
{
    public class UserController : BaseController
    {
        private IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _userRepository.GetAllAsync();
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetById([FromQuery] Guid Id)
        {
            var result = await _userRepository.GetByIdAsync(Id);

            if(result is null)
            {
                return BadRequest();
            }

            return Ok(result);
        }
    }
}
