using Application.DTO_S;

namespace Application.Services.IService;

public interface IRegisterService
{
    Task<bool> RegisterCompanyAsync(CreateCompanyDto dto);

    Task<bool> CreatePassword(CreatePasswordDto createPasswordDto);
}
