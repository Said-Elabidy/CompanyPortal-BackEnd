using Application.DTO_S;
using Application.Services.IService;
using Data.Entities;
using Domain.Repositories;

namespace Application.Services.Service;

public class CompanyService : ICompanyService
{
    private readonly IAccountRepository _accountRepository;
    private readonly IFileService _fileService;

    public CompanyService(IAccountRepository accountRepository, IFileService fileService)
    {
        _accountRepository = accountRepository;
        _fileService = fileService;
    }

    public async Task<bool> RegisterCompanyAsync(CreateCompanyDto createCompanyDto)
    {
        string logoPath = "";

        if (createCompanyDto.Logo != null && createCompanyDto.Logo.Length > 0)
        {
            using var stream = createCompanyDto.Logo.OpenReadStream();
            logoPath = await _fileService.SaveCompanyLogoAsync(stream, createCompanyDto.Logo.FileName);
        }

        var company = new ApplicationUser
        {
            ArabicCompanyName = createCompanyDto.ArabicName,
            EnglishCompanyName = createCompanyDto.EnglishName,
            Email = createCompanyDto.Email,
            PhoneNumber = createCompanyDto.PhoneNumber,
            WebsiteURL = createCompanyDto.WebsiteURL,
            LogoPath = logoPath
        };

        await _accountRepository.AddAccountAsync(company);

        return await _accountRepository.SaveChangesAsync();
    }
}
