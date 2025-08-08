using Application.DTO_S;

namespace Application.Services.IService;

public interface IRegisterService
{
    Task<string> RegisterCompanyAsync(CreateCompanyDto createCompanyDto);

    Task<bool> CreatePassword(CreatePasswordDto createPasswordDto);
}
