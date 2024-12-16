using WebRegister.DAL;
using WebRegister.DAL.Models;

namespace WebRegister.BLL;

public class SessionBLL(ISessionDAL sessionDal): ISessionBLL
{
    public SessionModel CreatSession(int UserId, string FingerPrint)
    {
        var oldSession = sessionDal.GetSessionByFingerPrint(FingerPrint);
        if (oldSession.Id != 0)
        {
            oldSession.RefreshToken = Guid.NewGuid().ToString();
            oldSession.CreatedAt = DateTime.UtcNow;
            oldSession.ExpiresIn = 60;
            sessionDal.UpdateSession(oldSession);
            return oldSession;
        }

        var NewSession = new SessionModel()
        {
            UserModelId = UserId,
            RefreshToken = Guid.NewGuid().ToString(),
            FingerPrint = FingerPrint,
            ExpiresIn = 60,
            CreatedAt = DateTime.UtcNow
        };
        sessionDal.CreateSession(NewSession);
        return NewSession;
    }

    public SessionModel UpdateSession(string ReFreshToken, string FingerPrint)
    {
        var oldSession = sessionDal.GetSessionByToken(ReFreshToken, FingerPrint);
        TimeSpan Dif = DateTime.UtcNow - oldSession.CreatedAt;
        if (Dif.Days > oldSession.ExpiresIn)
        {
            //TODO
        }
        oldSession.RefreshToken = Guid.NewGuid().ToString();
        sessionDal.UpdateSession(oldSession);
        return oldSession;
    }

    public void DeleteSession(string ReFreshToken, string FingerPrint)
    {
         sessionDal.DeleteSession(ReFreshToken, FingerPrint);
    }
}