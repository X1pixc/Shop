using Microsoft.AspNetCore.Mvc;
using WebRegister.BLL;
using WebRegister.BLL.Basket;
using WebRegister.DAL.Models;
using WebRegister.QueryModels;

namespace WebRegister.Controllers;
[ApiController]
public class BasketProductsController(IBasketProductsBLL basketProductsBll, IBasketBLL basketBll): ControllerBase
{
    [HttpPost("/basket/add-product")]
    public IActionResult AddProductToBasket([FromBody] QueryProductBasket model)
    {
        if (model.ProductId == null)
        {
            return BadRequest();
        }
        var basketProducts = new BasketProductsModel()
        {
            BasketId = basketBll.GetIdByUserId(int.Parse(Request.Headers["UserId"])),
            ProductId = model.ProductId
        };
        basketProductsBll.AddBasketProducts(basketProducts);
        return Ok();
    }

    [HttpPost("/basket/delete-product")]
    public IActionResult DeleteProductFromBasket([FromBody] QueryProductBasket model)
    {
        if (model.ProductId == null)
        {
            return BadRequest();
        }

        var basketId = basketBll.GetIdByUserId(int.Parse(Request.Headers["UserId"]));
        var basketProducts = basketProductsBll.GetBasketProductsByProductId(model.ProductId, basketId);
        basketProductsBll.DeleteBasketProducts(basketProducts);
        return Ok();
    }

    [HttpGet("/basket/{UserId}")]
    public IActionResult GetAllProductsFromBasket(int UserId)
    {
        var basketId = basketBll.GetIdByUserId(UserId);
        return Ok(basketProductsBll.GetAllProductsFromBasket(basketId));
    }
}