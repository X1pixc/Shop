using Microsoft.AspNetCore.Mvc;
using WebRegister.BLL.Profile;
using WebRegister.DAL.Models;

namespace WebRegister.Controllers;
[ApiController] 
public class ProfileController(IProfileBLL profileBll): ControllerBase
{
    [HttpPost("/profile/add")]
    public IActionResult AddProfile([FromBody] ProfileModel model)
    {
        profileBll.AddProfile(model);
        return Ok();
    }

    [HttpGet("/profile/Get/{Id}")]
    public IActionResult GetProfileById(string Id)
    {
        Console.WriteLine(Id);
        return Ok(profileBll.GetProfileById(int.Parse(Id)));
    }

    [HttpGet("/profile/GetByPhone")]
    public IActionResult GetProfileByPhone([FromBody] string Phone)
    {
        return Ok(profileBll.GetProfileByPhone(Phone));
    }

    [HttpGet("/profile/GetByEmail")]
    public IActionResult GetProfileByEmail([FromBody] string Email)
    {
        return Ok(profileBll.GetProfileByEmail(Email));
    }

    [HttpPut("/profile/Update")]
    public IActionResult UpdateProfile([FromBody] ProfileModel model)
    {
        profileBll.UpdateProfile(model);
        return Ok();
    }

    [HttpDelete("/Delete/{Id}")]
    public IActionResult DeleteModel(int Id)
    {
        var model = profileBll.GetProfileById(Id);
        profileBll.DeleteProfile(model);
        return Ok();
    }
    
    
}