using Application.Services.IService;
using Domain.Entities;
using Domain.IRepositories;

namespace Application.Services.Service
{
    public class OtpService : IOtpService
    {
        private readonly IOtpRepository _otpRepository;
        private readonly IEmailService _emailService;

        public OtpService(IOtpRepository otpRepository, IEmailService emailService)
        {
            _otpRepository = otpRepository;
            _emailService = emailService;
        }

        public async Task SendOtpAsync(string email)
        {
            var code = new Random().Next(100000, 999999).ToString();

            var otp = new OtpCode
            {
                Email = email,
                Code = code,
                ExpiryTime = DateTime.UtcNow.AddMinutes(5)
            };

            await _otpRepository.AddOtpAsync(otp);
            await _otpRepository.SaveChangesAsync();

            await _emailService.SendOtpEmailAsync(email, code);
        }

        public async Task<bool> VerifyOtpAsync(string email, string code)
        {
            var otp = await _otpRepository.GetValidOtpAsync(email, code);
            if (otp == null) return false;

            otp.IsUsed = true;
            await _otpRepository.SaveChangesAsync();
            return true;
        }
    }
}
