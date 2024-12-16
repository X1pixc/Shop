using WebRegister.DAL.Models;
using WebRegister.QueryModels;

namespace WebRegister.Mappers;

public class UserMapper
{
    public static UserModel MapUserModel(QueryUserModel model)
    {
        return new UserModel()
        {
            Login = model.Login,
            Password = model.Password,
            Email = model.Email
        };

    }
}