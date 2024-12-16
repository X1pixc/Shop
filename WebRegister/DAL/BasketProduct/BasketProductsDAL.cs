using Microsoft.EntityFrameworkCore;
using WebRegister.DAL.Models;

namespace WebRegister.DAL;

public class BasketProductsDAL: IBasketProductsDAL
{
    public void AddBasketProducts(BasketProductsModel basketProducts)
    {
        var connection = new DBHelper();
        connection.BasketProducts.Add(basketProducts);
        connection.SaveChanges();
    }

    public List<ProductModel> GetAllProductsFromBasket(int Id)
    {
        var connection = new DBHelper();
        var productsInBasket = connection.BasketProducts.Where(d => d.BasketId == Id).Select(d => d.product).ToList();
        return productsInBasket;
    }

    public BasketProductsModel GetBasketProductsById(int Id)
    {
        var connection = new DBHelper();
        return connection.BasketProducts.Find(Id);
    }

    public BasketProductsModel GetBasketProductsByProductId(int ProductId, int BasketId)
    {
        var connection = new DBHelper();
        return connection.BasketProducts.FirstOrDefault(c => c.ProductId == ProductId && c.BasketId == BasketId);
    }

    public void UpdateBasketProducts(BasketProductsModel basketProducts)
    {
        var connection = new DBHelper();
        connection.BasketProducts.Update(basketProducts);
        connection.SaveChanges();
    }

    public void DeleteBasketProducts(BasketProductsModel basketProducts)
    {
        var connection = new DBHelper();
        connection.BasketProducts.Remove(basketProducts);
        connection.SaveChanges();
    }
}