namespace Domain.Entities;

public class OtpCode
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Email { get; set; } = null!;
    public string Code { get; set; } = null!;
    public DateTime ExpiryTime { get; set; }
    public bool IsUsed { get; set; } = false;

}
