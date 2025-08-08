using Application.DTO_S;
using Application.Services.IService;
using Data.Entities;
using Domain.Repositories;
using Microsoft.AspNetCore.Identity;
using System.Text.RegularExpressions;

namespace Application.Services.Service;

public class RegisterService : IRegisterService
{
    private readonly IAccountRepository _accountRepository;
    private readonly IFileService _fileService;
    private readonly UserManager<ApplicationUser> _userManager;

    public RegisterService(IAccountRepository accountRepository, IFileService fileService , UserManager<ApplicationUser> userManager)
    {
        _accountRepository = accountRepository;
        _fileService = fileService;
        _userManager = userManager;
    }

    public async Task<string> RegisterCompanyAsync(CreateCompanyDto createCompanyDto)
    {
        if (await _accountRepository.EmailExistsAsync(createCompanyDto.Email))
            throw new Exception("Email already exists");

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
            LogoPath = logoPath,
            UserName = Regex.Replace(createCompanyDto.EnglishName, @"\s+", "")
        };

        await _accountRepository.AddAccountAsync(company);
        await _accountRepository.SaveChangesAsync();

        return company.Id;  
    }


    public async Task<bool> CreatePassword(CreatePasswordDto createPasswordDto)
    {
        var user = await _userManager.FindByIdAsync(createPasswordDto.UserId);
        if (user == null) return false;

        var result = await _userManager.AddPasswordAsync(user, createPasswordDto.Password);

        if (result.Succeeded)
        {
            user.IsVerified = true;
            await _userManager.UpdateAsync(user);
            return true;
        }
        else
        {
            
            foreach (var error in result.Errors)
            {
                Console.WriteLine($"Error: {error.Code} - {error.Description}");
            }
        }

        return false;
    }

}
