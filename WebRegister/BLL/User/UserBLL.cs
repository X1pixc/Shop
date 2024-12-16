using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using WebRegister.DAL;
using WebRegister.DAL.Models;

namespace WebRegister.BLL;

public class UserBLL(IUserDAL userDal): IUserBLL 
{
    public void Register(UserModel model)
    {
        model.Salt = Guid.NewGuid().ToString();
        model.Password = HashPassword(model.Password, model.Salt);
        userDal.AddUser(model);
    }

    public bool Login(string Login, string Password)
    {
        var model = userDal.GetByLogin(Login);
        if (model.Id == 0)
        {
            return false;
        }

        if (model.Password != HashPassword(Password, model.Salt))
        {
            return false;
        }
        
        return true;
    }

    public UserModel GetUserByLogin(string Login)
    {
        return userDal.GetByLogin(Login);
    }

    public string HashPassword(string password, string salt)
    {
        return Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password,
            System.Text.Encoding.ASCII.GetBytes(salt),
            KeyDerivationPrf.HMACSHA512,
            5000,
            64
        ));
    }
}