using WebRegister.DAL.Models;

namespace WebRegister.DAL;

public interface IUserDAL
{
    void AddUser(UserModel user);
    UserModel GetUser(int Id);
    UserModel GetByLogin(string name);
    List<UserModel> GetAllUsers();
    void UpdateUser(UserModel user);
    void DeleteUser(UserModel user);
}