namespace Application.Services.IService;

public interface IEmailService
{
    Task SendOtpEmailAsync(string toEmail, string otpCode);
}
