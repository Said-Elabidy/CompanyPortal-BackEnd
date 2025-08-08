using Application.DTO_S.Company;
using Application.Services.IService;
using Data.Entities;
using Domain.Repositories;
using Microsoft.AspNetCore.Identity;
 

namespace Application.Services.Service
{
    internal class CompanyService : ICompanyService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        public CompanyService(UserManager<ApplicationUser> userManager , IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
            _userManager = userManager;
        }

        public async Task<CompanyInfoDto?> GetCompanyInfoAsync(string userId)
        {
           
            var user = await _accountRepository.GetUserAsync(userId);
            if (user == null)
                return null;

           
            return new CompanyInfoDto
            {
                CompanyName = user.EnglishCompanyName,  
                LogoUrl = user.LogoPath  
            };
        }
    }
}
