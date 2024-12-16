using WebRegister.DAL.Models;

namespace WebRegister.DAL;

public class SessionDAL: ISessionDAL
{
    public void CreateSession(SessionModel Session)
    {
        var Connection = new DBHelper();
        Connection.Sessions.Add(Session);
        Connection.SaveChanges();
    }
    public SessionModel GetSessionByToken(string token, string FingerPrint)
    {
        var Connection = new DBHelper();
        return Connection.Sessions.FirstOrDefault(c => c.RefreshToken == token)?? new SessionModel();
    }

    public SessionModel GetSessionByFingerPrint(string fingerPrint)
    {
        var Connection = new DBHelper();
        return Connection.Sessions.FirstOrDefault(c => c.FingerPrint == fingerPrint)?? new SessionModel();
    }

    public void UpdateSession(SessionModel Session)
    {
        var Connection = new DBHelper();
        Connection.Sessions.Update(Session);
        Connection.SaveChanges();
    }

    public void DeleteSession(string refreshToken, string fingerPrint)
    {
        var Connection = new DBHelper();
        var s = Connection.Sessions.FirstOrDefault(c => c.RefreshToken == refreshToken && c.FingerPrint == fingerPrint);
        Connection.Sessions.Remove(s);
        Connection.SaveChanges();
    }
}