using CompanyPortalBackEnd.Extensions;
using Data.DbContext;
using Data.Entities;
using Application.Extensions;
using Infrastructure.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.FileProviders;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.AddPresentation();
        builder.Services.AddApplication();
        builder.Services.AddInfrastructure(builder.Configuration);

         

        builder.Services.AddControllers();

       
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", policy =>
            {
                policy.AllowAnyOrigin()
                      .AllowAnyMethod()
                      .AllowAnyHeader();
            });
        });

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseCors("AllowAll");

        app.UseAuthentication();  

        
        app.UseAuthorization();

        app.UseStaticFiles();

        app.MapControllers();

        app.Run();
    }
}
