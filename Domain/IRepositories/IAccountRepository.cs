using Data.Entities;

namespace Domain.Repositories;

public interface IAccountRepository
{
      Task AddAccountAsync(ApplicationUser applicationUser);

      Task<bool> DeleteAccount(string Id);
      Task<bool> SaveChangesAsync();

      Task<ApplicationUser?> GetUser(string Id);

}
