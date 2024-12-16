namespace WebRegister.DAL.Models;

public class SessionModel
{
    public int Id { get; set; }
    public int UserModelId { get; set; }
    public string RefreshToken { get; set; }
    public string FingerPrint { get; set; }
    public int ExpiresIn { get; set; }
    public DateTime CreatedAt { get; set; }
}