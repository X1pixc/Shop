using WebRegister.DAL.Models;
using WebRegister.DAL.Product;

namespace WebRegister.BLL;

public class ProductBLL(IProductDAL productDal): IProductBLL
{
    public void AddProduct(ProductModel product)
    {
        productDal.AddProduct(product);
    }

    public ProductModel GetProductById(int Id)
    {
        return productDal.GetProductById(Id);
    }

    public List<ProductModel> GetAllProducts()
    {
        return productDal.GetAllProducts();
    }

    public ProductModel GetProductByName(string Name)
    {
        return productDal.GetProductByName(Name);
    }

    public List<ProductModel> GetProductByUserId(int UserId)
    {
        return productDal.GetProductByUserId(UserId);
    }

    public void UpdateProduct(ProductModel product)
    {
        productDal.UpdateProduct(product);
    }

    public void DeleteProduct(ProductModel product)
    {
        productDal.DeleteProduct(product);
    }
}