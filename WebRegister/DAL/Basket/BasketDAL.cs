using WebRegister.DAL.Models;

namespace WebRegister.DAL;

public class BasketDAL:IBasketDAL
{
    public void AddBasket(BasketModel basket)
    {
        var connection = new DBHelper();
        connection.Baskets.Add(basket);
        connection.SaveChanges();
    }

    public BasketModel GetBasketById(int Id)
    {
        var connection = new DBHelper();
        return connection.Baskets.Find(Id);
    }

    public int GetIdByUserId(int UserId)
    {
        var connection = new DBHelper();
        return connection.Baskets.FirstOrDefault(c => c.UserId == UserId).Id;
    }

    public void UpdateBasket(BasketModel basket)
    {
        var connection = new DBHelper();
        connection.Baskets.Update(basket);
        connection.SaveChanges();
    }

    public void DeleteBasket(BasketModel basket)
    {
        var connection = new DBHelper();
        connection.Baskets.Remove(basket);
        connection.SaveChanges();
    }
}