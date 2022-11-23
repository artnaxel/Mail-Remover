using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MailRemoverAPI.Entities;
using MailRemoverAPI.Models.User;
using AutoMapper;
using MailRemoverAPI.Contracts;
using MailRemoverAPI.Exceptions;
using MailRemoverAPI.Data;

namespace MailRemoverAPI.Controllers
{
    [Route("api/[controller]")]


    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly MailRemoverDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<UsersController> _logger;
        private readonly IUsersRepository _usersRepository;

        public UsersController(IMapper mapper, ILogger<UsersController> logger, IUsersRepository usersRepository, MailRemoverDbContext context)
        {
            this._context = context;
            this._logger = logger;
            this._usersRepository = usersRepository;
            this._mapper = mapper;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetUserDto>>> GetUsers([FromQuery] string firstName)
        {
            _logger.LogInformation($"Getting all users for {firstName}");

            var users = await _usersRepository.GetAllAsync();
            var records = _mapper.Map<List<GetUserDto>>(users);
            //var queryedUsers = from user in records
            //                   where user.FirstName.Contains(firstName)
            //                   select user;

            var queryedUsers = records.Where(user => user.FirstName.Contains(firstName));
            
            return Ok(queryedUsers);
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetUserDto>> GetUser(Guid id)
        {
            _logger.LogInformation($"Getting user by id {id}");


            var user = await _usersRepository.GetAsync(id);

            if(user == null) {
                throw new NotFoundException(nameof(GetUser), id);
            }

            var userDto = _mapper.Map<GetUserDto>(user);
            return Ok(userDto);
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(Guid id, UpdateUserDto updateUserDto)
        {
            _logger.LogInformation($"Registering user with put {id}");
            
            if (id != updateUserDto.Id)
            {
                throw new BadRequestException("Requset bad in: " + nameof(PutUser) + ". Invalid Record Id", id.ToString());
            }

            var user = await _usersRepository.GetAsync(id);
            _context.Entry(user).State = EntityState.Modified;

            if (user == null) 
            {
                throw new NotFoundException(nameof(PutUser), id);
            }

            var updatedUser = _mapper.Map(updateUserDto, user);
            await _usersRepository.UpdateAsync(user);

            return Ok(updatedUser);
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(CreateUserDto createUserDto)
        {
            _logger.LogInformation($"Registering user {createUserDto}");


    
            var user = _mapper.Map<User>(createUserDto);
            

            if (user == null)
            {
                throw new BadRequestException(nameof(PostUser));
            }

            await _usersRepository.AddAsync(user);

            return CreatedAtAction("GetUser", new { id = Guid.NewGuid() }, user);




        }

        // POST: api/Users/login
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("/login")]
        public async Task<ActionResult<User>> LoginUser(Guid id, string Password)
        {
            _logger.LogInformation($"Loging in user {id}");

                var user = await _usersRepository.GetAsync(id);

                if (user == null)
                {
                    throw new UnauthorizedException("In: " + nameof(LoginUser) + " there was an error. Either id or password is wrong.");
                }
                else
                {
                    var result = user.CheckPassword(Password);
                    if (result == false)
                    {
                        throw new UnauthorizedException("In: " + nameof(LoginUser) + " there was an error. Either id or password is wrong.");
                    }
                    else
                    {
                        return Ok(user);
                    }
                }
        }



        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            _logger.LogInformation($"Deleting user {id}");

                var user = await _usersRepository.GetAsync(id);
                if (user == null)
                {
                    throw new NotFoundException(nameof(GetUser), id);
                }

                await _usersRepository.DeleteAsync(id);

                return NoContent();
        }

        private async Task<bool> UserExists(Guid id)
        {
            return await _usersRepository.Exists(id);
        }
    }
}
