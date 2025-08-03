using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Application.DTO_S;

public class CreatePasswordDto
{
    public string UserId { get; set; }


    [Required(ErrorMessage = "Password is required.")]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*#?&]).{8,}$",
    ErrorMessage = "Password must be at least 8 characters, contain uppercase, number and special character.")]
    [PasswordPropertyText]
     public string Password { get; set; }

    [Required(ErrorMessage = "Password confirmation is required.")]
    [Compare("Password", ErrorMessage = "Password and confirmation do not match.")]
    public string ConfirmPassword { get; set; }
}
