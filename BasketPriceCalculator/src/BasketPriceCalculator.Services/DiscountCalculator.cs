using BasketPriceCalculator.Domain;

namespace BasketPriceCalculator.Services
{
    public interface IDiscountCalculator
    {
        Discount CalculateDiscount(IBasket basket);
    }

    public class DiscountCalculator : IDiscountCalculator
    {
        private readonly IOfferService _offerService;

        public DiscountCalculator(IOfferService offerService)
        {
            _offerService = offerService;
        }

        public Discount CalculateDiscount(IBasket basket)
        {
            throw new System.NotImplementedException();
        }
    }
}