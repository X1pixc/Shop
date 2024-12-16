using WebRegister.DAL.Models;

namespace WebRegister.DAL;

public interface ISessionDAL
{
    void CreateSession(SessionModel Session);
    SessionModel GetSessionByToken(string token, string FingerPrint);
    SessionModel GetSessionByFingerPrint(string fingerPrint);
    void UpdateSession(SessionModel Session);
    void DeleteSession(string refreshToken, string fingerPrint);
}