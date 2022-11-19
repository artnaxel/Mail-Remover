using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MailRemoverAPI.Entities;
using MailRemoverAPI.Models.User;
using AutoMapper;
using MailRemoverAPI.Data;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace MailRemoverAPI.Controllers
{
    [Route("api/[controller]")]


    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly MailRemoverDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<UsersController> _logger;

        public UsersController(MailRemoverDbContext context, IMapper mapper, ILogger<UsersController> logger)
        {
            _context = context;
            this._logger = logger;
            this._mapper = mapper;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetUserDto>>> GetUsers([FromQuery] string firstName)
        {
            _logger.LogInformation($"Getting all users for {firstName}");
            try
            {
                //throw new OutOfMemoryException();
                var users = await _context.Users.ToListAsync();
                var records = _mapper.Map<List<GetUserDto>>(users);
                var queryedUsers = from user in records
                                   where user.FirstName.Contains(firstName)
                                   select user;
                return Ok(queryedUsers);
                //return Ok(records);
                
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(GetUsers)}");
                return Problem($"Something went wrong in the {nameof(GetUsers)}", statusCode: 500);
            }
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDetailsDto>> GetUser(Guid id)
        {
            _logger.LogInformation($"Getting user by id {id}");
            try
            {
                //throw new OutOfMemoryException();
                var user = await _context.Users.Include(q => q.Emails).FirstOrDefaultAsync(q => q.Id == id);

                if(user == null) { 
                    return NotFound(); 
                }

                var UserDto = _mapper.Map<UserDetailsDto>(user);
                return Ok(UserDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(GetUser)}");
                return Problem($"Something Went Wrong in the {nameof(GetUser)}", statusCode: 500);
            }
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(Guid id, User user)
        {
            _logger.LogInformation($"Registering user with put {id}");
            _context.Entry(user).State = EntityState.Modified;


            if (id != user.Id)
            {
                return BadRequest();
            }

            

            try
            {
                //throw new OutOfMemoryException();
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    _logger.LogError(ex, $"Something Went Wrong in the {nameof(PutUser)}");
                    return Problem($"Something Went Wrong in the {nameof(PutUser)}", statusCode: 500);
                }
            }

            return NoContent();
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(CreateUserDto createUserDto)
        {
            _logger.LogInformation($"Registering user {createUserDto}");

            try
            {
                //throw new OutOfMemoryException();
                var user = _mapper.Map<User>(createUserDto);

                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetUser", new { id = Guid.NewGuid() }, user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the registrstion of {nameof(PostUser)}");
                return Problem($"Something went wrong in the registrstion of {nameof(PostUser)}", statusCode: 500);
            }


        }

        // POST: api/Users/login
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("/login")]
        public async Task<ActionResult<User>> LoginUser(Guid id, string Password)
        {
            _logger.LogInformation($"Loging in user {id}");

            try
            {
                //throw new OutOfMemoryException();
                var user = await _context.Users.FindAsync(id);

                if (user == null)
                {
                    return NotFound();
                }
                else
                {
                    var result = user.CheckPassword(Password);
                    if (result == false)
                    {
                        return Ok("Wrong Password");
                    }
                    else
                    {
                        return Ok(user);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the loging in of {nameof(LoginUser)}");
                return Problem($"Something went wrong in the loging in of {nameof(LoginUser)}", statusCode: 500);
            }

        }



        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            _logger.LogInformation($"Deleting user {id}");

            try
            {
                //throw new OutOfMemoryException();
                var user = await _context.Users.FindAsync(id);
                if (user == null)
                {
                    return NotFound();
                }

                _context.Users.Remove(user);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the deletion of {nameof(DeleteUser)}");
                return Problem($"Something went wrong in the deletion of {nameof(DeleteUser)}", statusCode: 500);
            }
            

        }

        private bool UserExists(Guid id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
