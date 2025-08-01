using Application.DTO_S;

namespace Application.Services.IService;

public interface ICompanyService
{
    Task<bool> RegisterCompanyAsync(CreateCompanyDto dto);
}
