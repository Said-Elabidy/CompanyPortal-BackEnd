public class FileService : IFileService
{
    private bool IsImageFile(Stream stream)
    {
        stream.Position = 0;
        Span<byte> header = stackalloc byte[8];
        stream.Read(header);

        // JPEG signature: FF D8
        if (header[0] == 0xFF && header[1] == 0xD8)
            return true;

        // PNG signature: 89 50 4E 47 0D 0A 1A 0A
        if (header.Slice(0, 8).SequenceEqual(new byte[] { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A }))
            return true;

        // GIF signature: GIF87a or GIF89a
        if ((header[0] == 'G') && (header[1] == 'I') && (header[2] == 'F'))
            return true;

        return false;
    }
    public async Task<string> SaveCompanyLogoAsync(Stream fileStream, string fileName)
    {
        var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
        var maxFileSize = 5 * 1024 * 1024; // 5MB

        var extension = Path.GetExtension(fileName).ToLower();

        // 1. Check extension
        if (!allowedExtensions.Contains(extension))
            throw new InvalidOperationException("Invalid file extension. Only image files are allowed.");

        // 2. Read stream into memory to validate size and file signature
        using var memoryStream = new MemoryStream();
        await fileStream.CopyToAsync(memoryStream);

        // 3. Check size
        if (memoryStream.Length > maxFileSize)
            throw new InvalidOperationException("File is too large. Max allowed size is 5MB.");

        // 4. Check file signature (basic check for JPEG and PNG)
        if (!IsImageFile(memoryStream))
            throw new InvalidOperationException("Invalid file content. Only image files are allowed.");

        // 5. Save file
        memoryStream.Position = 0; // reset position after reading
        var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Logos");

        if (!Directory.Exists(uploadsFolder))
            Directory.CreateDirectory(uploadsFolder);

        var uniqueName = Guid.NewGuid().ToString() + extension;
        var filePath = Path.Combine(uploadsFolder, uniqueName);

        using var outputStream = new FileStream(filePath, FileMode.Create);
        await memoryStream.CopyToAsync(outputStream);

        return Path.Combine("Logos", uniqueName);
    }

}

