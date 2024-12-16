using Microsoft.AspNetCore.Mvc;
using WebRegister.BLL.Basket;
using WebRegister.DAL.Models;

namespace WebRegister.Controllers;
[ApiController]
public class BasketController(IBasketBLL basketBll): ControllerBase
{
    [HttpPost("/add-basket")]
    public IActionResult AddBasket([FromBody] BasketModel basket)
    {
        if (basket == null)
        {
            return BadRequest();
        }
        basketBll.AddBasket(basket);
        return Ok();
    }
    [HttpPut("/update-basket")]
    public IActionResult UpdateBasket(BasketModel basket)
    {
        if (basket == null)
        {
            return BadRequest();
        }
        basketBll.UpdateBasket(basket);
        return Ok();
    }

    [HttpDelete("/delete-basket/{Id}")]
    public IActionResult DeleteBasket(int Id)
    {
        if (Id == 0)
        {
            return BadRequest();
        }

        var model = basketBll.GetBasketById(Id);
        basketBll.DeleteBasket(model);
        return Ok();
    }
}