using WebRegister.DAL;
using WebRegister.DAL.Models;

namespace WebRegister.BLL;

public class BasketProductsBLL(IBasketProductsDAL productsDal) : IBasketProductsBLL
{
    public void AddBasketProducts(BasketProductsModel basketProducts)
    {
        productsDal.AddBasketProducts(basketProducts);
    }

    public BasketProductsModel GetBasketProductsByProductId(int ProductId, int BasketId)
    { 
        return productsDal.GetBasketProductsByProductId(ProductId, BasketId);
    }

    public List<ProductModel> GetAllProductsFromBasket(int Id)
    {
        return productsDal.GetAllProductsFromBasket(Id);
    }

    public BasketProductsModel GetBasketProductsById(int Id)
    {
        return productsDal.GetBasketProductsById(Id);
    }

    public void UpdateBasketProducts(BasketProductsModel basketProducts)
    {
        productsDal.UpdateBasketProducts(basketProducts);
    }

    public void DeleteBasketProducts(BasketProductsModel basketProducts)
    {
        productsDal.DeleteBasketProducts(basketProducts);
    }
}