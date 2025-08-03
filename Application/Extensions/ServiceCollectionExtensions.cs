using Application.Services.IService;
using Application.Services.Service;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel.Design;

namespace Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IRegisterService, RegisterService>();
        services.AddScoped<IOtpService, OtpService>();
    }
}
