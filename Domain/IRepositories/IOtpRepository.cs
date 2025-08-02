
using Domain.Entities;

namespace Domain.IRepositories
{
    public interface IOtpRepository
    {
        Task AddOtpAsync(OtpCode otp);
        Task<OtpCode?> GetValidOtpAsync(string email, string code);
        Task SaveChangesAsync();
    }
}
