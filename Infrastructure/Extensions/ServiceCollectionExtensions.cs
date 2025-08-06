using Application.Services.IService;
using Microsoft.Extensions.Options;
using Data.DbContext;
using Domain.IRepositories;
using Domain.Repositories;
using Infrastructure.Repositories;
using Infrastructure.Settings;
 using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Services;

namespace Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<ApplicationDbContext>(options =>
               options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            var jwtSettings = configuration.GetSection("JwtSettings").Get<JwtSettings>();
            services.AddSingleton(jwtSettings);

            services.AddScoped<IFileService, FileService>();

            services.AddScoped<IAccountRepository, AccountRepository>();

            services.AddScoped<IEmailService, EmailService>();

            services.AddScoped<IOtpRepository, OtpRepository>();

            services.AddScoped<IAuthService, AuthService>();

        }
    }
}
