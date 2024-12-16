using WebRegister.DAL.Models;

namespace WebRegister.DAL;

public interface IBasketProductsDAL
{
    public void AddBasketProducts(BasketProductsModel basketProducts);
    public List<ProductModel> GetAllProductsFromBasket(int Id);
    public BasketProductsModel GetBasketProductsById(int Id);
    
    public BasketProductsModel GetBasketProductsByProductId(int ProductId, int BasketId);
    public void UpdateBasketProducts(BasketProductsModel basketProducts);
    public void DeleteBasketProducts(BasketProductsModel basketProducts);
}