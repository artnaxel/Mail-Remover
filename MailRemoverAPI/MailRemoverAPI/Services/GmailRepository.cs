using AutoMapper;
using MailRemoverAPI.Data;
using MailRemoverAPI.Entities;
using MailRemoverAPI.Interfaces;
using MailRemoverAPI.Models.Gmail;
using MailRemoverAPI.Models.User;

namespace MailRemoverAPI.Services
{
    public class GmailRepository : IGmailRepository
    {
        private readonly MailRemoverDbContext _context;
        private readonly IMapper _mapper;

        public GmailRepository(MailRemoverDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public Task<List<Gmail>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Gmail?> GetByIdAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public async Task<Guid> CreateAsync(GmailDto gmailDto)
        {
            var gmail = _mapper.Map<Gmail>(gmailDto);

            _context.Gmails.Add(gmail);
            await _context.SaveChangesAsync();
            return new();
        }
    }
}
