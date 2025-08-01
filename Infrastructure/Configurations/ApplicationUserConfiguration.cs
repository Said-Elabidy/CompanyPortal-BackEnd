using Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Data.Configurations;

public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
       
        builder.Property(e => e.ArabicCompanyName)
               .IsRequired()
               .HasMaxLength(200);

       
        builder.Property(e => e.EnglishCompanyName)
               .IsRequired()
               .HasMaxLength(200);

        
        builder.Property(e => e.WebsiteURL)
               .HasMaxLength(300);

        
        builder.Property(e => e.LogoPath)
               .HasMaxLength(500);

   
        builder.Property(e => e.OTP)
               .HasMaxLength(10);

       
        builder.Property(e => e.IsVerified)
               .HasDefaultValue(false);
    }
}
