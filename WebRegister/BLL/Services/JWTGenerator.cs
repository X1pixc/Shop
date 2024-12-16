using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace WebRegister.BLL.Services;

public class JWTGenerator
{
    public static string CreateToken(int UserId, string Login)
    {
        var SecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("hJ3r85MpN4Xq7V3kGr2ZwH6lS1dY9tZc"));
        var Credentials = new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha256);
        var Claims = new[]
        {
            new Claim("UserId", UserId.ToString()),
            new Claim("Login", Login)
        };
        var Token = new JwtSecurityToken(
            "WebRegister", "WebRegister", expires: DateTime.Now.AddHours(0.5), signingCredentials: Credentials,
            claims: Claims
        );
        return new JwtSecurityTokenHandler().WriteToken(Token);
    }
    
}