using System.Collections.Generic;

namespace BasketPriceCalculator.Services
{
    public interface IOfferService
    {
        IList<IOffer> GetOffers();
    }
}