namespace WebRegister.DAL.Models;

public class BasketProductsModel
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int BasketId { get; set; }
    public BasketModel basket { get; set; }
    public ProductModel product { get; set; }
}