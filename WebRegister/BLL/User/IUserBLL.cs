using WebRegister.DAL.Models;

namespace WebRegister.BLL;

public interface IUserBLL
{
    void Register(UserModel model);
    bool Login(string Login, string Password);
    UserModel GetUserByLogin(string Login);
}