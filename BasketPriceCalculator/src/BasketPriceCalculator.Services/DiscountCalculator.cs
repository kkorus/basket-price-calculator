using BasketPriceCalculator.Domain;

namespace BasketPriceCalculator.Services
{
    public class DiscountCalculator : IDiscountCalculator
    {
        private readonly IOfferService _offerService;

        public DiscountCalculator(IOfferService offerService)
        {
            _offerService = offerService;
        }

        public Discount CalculateDiscount(IBasket basket)
        {
            var discount = 0m;
            var offers = _offerService.GetOffers();
            foreach (var offer in offers)
            {
                while (basket.Contains(offer.OfferProducts))
                {
                    discount += offer.PriceCut;
                    basket = basket.Remove(offer.OfferProducts);
                }
            }

            return new Discount(discount);
        }
    }
}