using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebRegister.BLL;
using WebRegister.DAL.Models;
using WebRegister.QueryModels;

namespace WebRegister.Controllers;
[Authorize]
[ApiController]
public class ProductController(IProductBLL productBll, IWebHostEnvironment _environment): ControllerBase
{
    [HttpPost("/add-product")]
    public IActionResult AddProduct([FromBody] ProductModel product)
    {
        if (product == null)
        {
            return BadRequest();
        }
        productBll.AddProduct(product);
        return Ok();
    }

    [HttpGet("/get/{Id}")]
    public IActionResult GetProductById(int Id)
    {
        if (Id == 0)
        {
            return BadRequest();
        }
        var model = productBll.GetProductById(Id);
        return Ok(model);
    }

    [HttpGet("/get-all")]
    public IActionResult GetAllProducts()
    {
        var model = productBll.GetAllProducts();
        return Ok(model);
    }

    [HttpGet("/get")]
    public IActionResult GetProductByName([FromBody]string Name)
    {
        if (Name == null)
        {
            return BadRequest();
        }
        var model = productBll.GetProductByName(Name);
        return Ok(model);
    }

    [HttpGet("/user-products/{UserId}")]
    public IActionResult GetProductByUserId(int UserId)
    {
        if (UserId == 0)
        {
            return BadRequest();
        }
        var model = productBll.GetProductByUserId(UserId);
        return Ok(model);
    }

    [HttpPut("/update-product")]
    public IActionResult UpdateProduct([FromBody] ProductModel product)
    {
        if (product == null)
        {
            return BadRequest();
        }
        productBll.UpdateProduct(product);
        return Ok();
    }

    [HttpDelete("/delete-product/{Id}")]
    public IActionResult DeleteProduct(int Id)
    {
        if (Id == 0)
        {
            return BadRequest();
        }
        var model = productBll.GetProductById(Id);
        productBll.DeleteProduct(model);
        return Ok();
    }
}