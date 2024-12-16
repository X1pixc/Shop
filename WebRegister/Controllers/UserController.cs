using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebRegister.BLL;
using WebRegister.BLL.Services;
using WebRegister.Mappers;
using WebRegister.QueryModels;

namespace WebRegister.Controllers;
[ApiController]
public class UserController(IUserBLL userBll, ISessionBLL sessionBll):ControllerBase
{
    [HttpPost("/register")]
    public IActionResult Register([FromBody] QueryUserModel model)
    {
        if (model.Login == null || model.Login.Length < 3)
        {
            return BadRequest();
        }

        if (model.Password == null || model.Password.Length < 6)
        {
            return BadRequest();
        }
        
        if (model.Email == null || !model.Email.Contains("@"))
        {
            return BadRequest();
        }
        userBll.Register(UserMapper.MapUserModel(model));
        return Ok();
    }

    [HttpPost("/auth")]
    public IActionResult Auth([FromBody] QueryLoginModel model)
    {
        var Login = model.Login;
        var Password = model.Password;
        var FingerPrint = Request.Headers["FingerPrint"];
        Console.WriteLine(Login);
        if (Login == null || Login.Length < 3)
        {
            return BadRequest();
        }
        if (!userBll.Login(Login, Password))
        {
            return Unauthorized();
        }

        var User = userBll.GetUserByLogin(Login);
        var Session = sessionBll.CreatSession(User.Id, FingerPrint);
        var JWT = JWTGenerator.CreateToken(User.Id, User.Login);
        var Response = new
        {
            UserId = User.Id,
            AccessToken = JWT,
            RefreshToken = Session.RefreshToken
        };
        return Ok(Response);
    }
}