using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public class ApplicationUser : IdentityUser 
{
    // Id , Email and Password will handle by IdentityUser
  

    // Required Properties
     
    public string ArabicCompanyName { get; set; }  
    public string EnglishCompanyName { get; set; } 

    // Optional Properties
    public string? WebsiteURL { get; set; }
    public string? LogoPath { get; set; }
    public string? OTP { get; set; }
    public bool IsVerified { get; set; } = false;
}
