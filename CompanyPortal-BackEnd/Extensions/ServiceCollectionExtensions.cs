using Data.DbContext;
using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;
using Org.BouncyCastle.Asn1.X509;

namespace CompanyPortalBackEnd.Extensions
{
    public static class WebApplicationBuilderExtensions
    {
        public static void AddPresentation(this WebApplicationBuilder builder)
        {
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                // Password settings
                options.Password.RequireDigit = true;              
                options.Password.RequiredLength = 7;               
                options.Password.RequireUppercase = true;          
                options.Password.RequireNonAlphanumeric = true;    
                options.Password.RequireLowercase = false;         
                options.Password.RequiredUniqueChars = 1;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();
        }
    }
}
