using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Domain.Repositories;

public class FileService : IFileService
{
    public async Task<string> SaveCompanyLogoAsync(Stream fileStream, string fileName)
    {
        var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Logos");

        if (!Directory.Exists(uploadsFolder))
            Directory.CreateDirectory(uploadsFolder);

        var uniqueName = Guid.NewGuid().ToString() + Path.GetExtension(fileName);
        var filePath = Path.Combine(uploadsFolder, uniqueName);

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await fileStream.CopyToAsync(stream);
        }

        return Path.Combine("Logos", uniqueName); // دا اللي يتخزن في الـ DB
    }
}
 
