using WebRegister.DAL.Models;

namespace WebRegister.DAL;

public class UserDAL: IUserDAL
{
    public void AddUser(UserModel user)
    {
        var Connection = new DBHelper();
        Connection.Users.Add(user);
        Connection.SaveChanges();
    }

    public UserModel GetUser(int Id)
    {
        var Connection = new DBHelper();
        return Connection.Users.Find();
    }

    public UserModel GetByLogin(string name)
    {
        var Connection = new DBHelper(); 
        return Connection.Users.FirstOrDefault(u => u.Login == name)?? new UserModel();
    }

    public List<UserModel> GetAllUsers()
    {
        var Connection = new DBHelper();
        return Connection.Users.ToList();
    }

    public void UpdateUser(UserModel user)
    {
        var Connection = new DBHelper();
        Connection.Users.Update(user);
        Connection.SaveChanges();
    }

    public void DeleteUser(UserModel user)
    {
        var Connection = new DBHelper();
        Connection.Users.Remove(user);
        Connection.SaveChanges();
    }
}