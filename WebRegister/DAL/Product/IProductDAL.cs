using WebRegister.DAL.Models;

namespace WebRegister.DAL.Product;

public interface IProductDAL
{
    void AddProduct(ProductModel product);
    ProductModel GetProductById(int Id);
    List<ProductModel> GetAllProducts();
    ProductModel GetProductByName(string Name);
    List<ProductModel> GetProductByUserId(int UserId);
    void UpdateProduct(ProductModel product);
    void DeleteProduct(ProductModel product);
}