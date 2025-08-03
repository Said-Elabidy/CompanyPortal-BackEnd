using Data.DbContext;
using Data.Entities;
using Domain.Repositories;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class AccountRepository(ApplicationDbContext context) : IAccountRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task AddAccountAsync(ApplicationUser applicationUser)
    {
       await _context.ApplicationUsers.AddAsync(applicationUser);
    }

    public async Task<bool> DeleteAccount(string id)
    {
        var user = await _context.ApplicationUsers.FindAsync(id);
        

        if (user == null) return false;

        _context.ApplicationUsers.Remove(user);

        return true;
    }

    public async Task<ApplicationUser?> GetUserAsync(string Id)
    {
         return await _context.ApplicationUsers.FindAsync(Id)  ;
    }



    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }
}
