using Data.DbContext;
using Domain.Entities;
using Domain.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class OtpRepository : IOtpRepository
    {
        private readonly ApplicationDbContext _context;

        public OtpRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddOtpAsync(OtpCode otp)
        {
            await _context.OtpCodes.AddAsync(otp);
        }

        public async Task<OtpCode?> GetValidOtpAsync(string email, string code)
        {
            return await _context.OtpCodes
                .FirstOrDefaultAsync(o => o.Email == email && o.Code == code && !o.IsUsed && o.ExpiryTime > DateTime.UtcNow);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
