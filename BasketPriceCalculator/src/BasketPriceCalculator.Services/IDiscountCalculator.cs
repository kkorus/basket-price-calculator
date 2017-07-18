using BasketPriceCalculator.Domain;

namespace BasketPriceCalculator.Services
{
    public interface IDiscountCalculator
    {
        Discount CalculateDiscount(IBasket basket);
    }
}