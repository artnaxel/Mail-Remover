using AutoMapper;
using MailRemoverAPI.Data;
using MailRemoverAPI.Entities;
using MailRemoverAPI.Interfaces;
using MailRemoverAPI.Models.Gmail;
using MailRemoverAPI.Models.User;
using Microsoft.EntityFrameworkCore;

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


        public async Task<List<Gmail>> GetAllAsync()
        {
            var gmails = await _context.Gmails.ToListAsync();
            return gmails;
        }

        public async Task<Gmail?> GetByIdAsync(Guid Id)
        {
            var gmail = await _context.Gmails.FindAsync(Id);
            return gmail;
        }

        public async Task<Guid> CreateAsync(GmailDto gmailDto)
        {
            var gmail = _mapper.Map<Gmail>(gmailDto);

            _context.Gmails.Add(gmail);
            await _context.SaveChangesAsync();
            return new();
        }

        public async Task UpdateAsync(Gmail gmail)
        {
            var local = _context.Gmails
                .Local
                .FirstOrDefault(oldGmail => oldGmail.Id == gmail.Id);

            if (local != null)
            {
                _context.Entry(local).State = EntityState.Detached;
            }

            if (gmail == null)
                 throw new ArgumentNullException(nameof(gmail));

            _context.Entry(gmail).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
