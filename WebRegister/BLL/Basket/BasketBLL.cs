using WebRegister.DAL;
using WebRegister.DAL.Models;

namespace WebRegister.BLL.Basket;

public class BasketBLL(IBasketDAL basketDal):IBasketBLL
{
    public void AddBasket(BasketModel basket)
    {
        basketDal.AddBasket(basket);
    }

    public BasketModel GetBasketById(int Id)
    {
        return basketDal.GetBasketById(Id);
    }

    public int GetIdByUserId(int UserId)
    {
        return basketDal.GetIdByUserId(UserId);
    }

    public void UpdateBasket(BasketModel basket)
    {
        basketDal.UpdateBasket(basket);
    }

    public void DeleteBasket(BasketModel basket)
    {
        basketDal.DeleteBasket(basket);
    }
}