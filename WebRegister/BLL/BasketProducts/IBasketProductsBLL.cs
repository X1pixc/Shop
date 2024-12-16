using WebRegister.DAL.Models;

namespace WebRegister.BLL;

public interface IBasketProductsBLL
{
    public void AddBasketProducts(BasketProductsModel basketProducts);
    
    public BasketProductsModel GetBasketProductsByProductId(int ProductId, int BasketId);
    public List<ProductModel> GetAllProductsFromBasket(int Id);
    public BasketProductsModel GetBasketProductsById(int Id);
    public void UpdateBasketProducts(BasketProductsModel basketProducts);
    public void DeleteBasketProducts(BasketProductsModel basketProducts);
}