namespace WebRegister.DAL.Models;

public class BasketModel
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int TotalPrice { get; set; }
    public List<BasketProductsModel> BasketProducts { get; set; }
}