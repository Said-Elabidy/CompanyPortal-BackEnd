namespace Application.Services.IService
{
    public interface IOtpService
    {
        Task SendOtpAsync(string email);
        Task<bool> VerifyOtpAsync(string email, string code);    
    }
}
