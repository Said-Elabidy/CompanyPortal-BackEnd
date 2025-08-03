using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;


namespace Application.DTO_S;

public class CreateCompanyDto
{
    [Required(ErrorMessage = "Arabic name is required")]
    [MaxLength(100, ErrorMessage = "Arabic name can't exceed 100 characters")]
    public string ArabicName { get; set; }

    [Required(ErrorMessage = "English name is required")]
    [MaxLength(100, ErrorMessage = "English name can't exceed 100 characters")]
    public string EnglishName { get; set; }

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email address")]
    public string Email { get; set; }

    [Phone(ErrorMessage = "Invalid phone number")]
    public string? PhoneNumber { get; set; }

    [Url(ErrorMessage = "Invalid website URL")]
    public string? WebsiteURL { get; set; }

    // Optional, but if provided, should be an image and max size e.g., 2MB
    public IFormFile? Logo { get; set; }
}

