using Application.DTO_S.Company;

namespace Application.Services.IService;

public interface ICompanyService
{
    Task<CompanyInfoDto> GetCompanyInfoAsync(string userId);
}
