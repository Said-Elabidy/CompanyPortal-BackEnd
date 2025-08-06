using Application.DTO_S;

namespace Application.Services.IService;

public interface IAuthService
{
    Task<string> LoginAsync(LoginDto loginDto);
    
}
