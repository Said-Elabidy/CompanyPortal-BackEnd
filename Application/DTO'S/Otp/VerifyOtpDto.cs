namespace Application.DTO_S.SendOtpDto.cs;

public class VerifyOtpDto
{
    public string Email { get; set; } = null!;
    public string Code { get; set; } = null!;
}
