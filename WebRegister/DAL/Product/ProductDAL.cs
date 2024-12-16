using Microsoft.EntityFrameworkCore;
using WebRegister.DAL.Models;

namespace WebRegister.DAL.Product;

public class ProductDAL: IProductDAL
{
    public void AddProduct(ProductModel product)
    {
        var connection = new DBHelper();
        connection.Products.Add(product);
        connection.SaveChanges();
    }

    public ProductModel GetProductById(int Id)
    {
        var connection = new DBHelper();
        return connection.Products.Find(Id) ?? new ProductModel();
    }

    public List<ProductModel> GetAllProducts()
    {
        var connection = new DBHelper();
        return connection.Products.ToList();
    }

    public ProductModel GetProductByName(string Name)
    {
        var connection = new DBHelper();
        return connection.Products.FirstOrDefault(c => c.Name == Name) ?? new ProductModel();
    }

    public List<ProductModel> GetProductByUserId(int UserId)
    {
        var connection = new DBHelper();
        return connection.Products.Where(c => c.UserId == UserId).ToList();
    }

    public void UpdateProduct(ProductModel product)
    {
        var connection = new DBHelper();
        connection.Products.Update(product);
        connection.SaveChanges();
    }

    public void DeleteProduct(ProductModel product)
    {
        var connection = new DBHelper();
        connection.Products.Remove(product);
        connection.SaveChanges();
    }
}