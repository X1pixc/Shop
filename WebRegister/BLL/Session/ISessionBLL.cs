using WebRegister.DAL.Models;

namespace WebRegister.BLL;

public interface ISessionBLL
{
    SessionModel CreatSession(int UserId, string FingerPrint);
    SessionModel UpdateSession(string ReFreshToken, string FingerPrint);
    void DeleteSession(string ReFreshToken, string FingerPrint);
}