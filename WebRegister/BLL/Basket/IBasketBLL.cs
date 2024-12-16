using WebRegister.DAL.Models;

namespace WebRegister.BLL.Basket;

public interface IBasketBLL
{
    public void AddBasket(BasketModel basket);
    public BasketModel GetBasketById(int Id);
    public int GetIdByUserId(int UserId);
    public void UpdateBasket(BasketModel basket);
    public void DeleteBasket(BasketModel basket);
}