using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repositories;

public interface IAccountRepository
{
      Task AddAccountAsync(ApplicationUser applicationUser);

      Task<bool> DeleteAccount(string Id);
      Task<bool> SaveChangesAsync();

    Task<bool> EmailExistsAsync(string email);
    Task<ApplicationUser?> GetUserAsync(string Id);

}
