using System.Collections.Generic;

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
            throw new System.NotImplementedException();
        }
    }
}