using Microsoft.AspNetCore.Http;

public interface IFileService
{
    Task<string> SaveCompanyLogoAsync(Stream fileStream, string fileName);

}