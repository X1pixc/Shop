namespace WebRegister.QueryModels;

public class QueryProductModel
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public string Description { get; set; }
    public IFormFile ProductPhoto { get; set; }
}