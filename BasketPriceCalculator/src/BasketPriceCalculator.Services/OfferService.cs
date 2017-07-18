using System.Collections.Generic;
using BasketPriceCalculator.Domain;

namespace BasketPriceCalculator.Services
{
    public class OfferService : IOfferService
    {
        private readonly IPriceService _priceService;

        public OfferService(IPriceService priceService)
        {
            _priceService = priceService;
        }

        public IList<IOffer> GetOffers()
        {
            return new List<IOffer>
            {
                new Offer
                {
                    Name = "Buy 2 Butter and get a Bread at 50% off",
                    OfferProducts = new[] {new BasketProduct("butter", 2), new BasketProduct("bread", 1)},
                    PriceCut = _priceService.GetPriceFor("bread") / 2
                },
                new Offer
                {
                    Name = "Buy 3 Milk and get the 4th milk for free",
                    OfferProducts = new[] {new BasketProduct("milk", 4)},
                    PriceCut = _priceService.GetPriceFor("milk")
                }
            };
        }
    }
}