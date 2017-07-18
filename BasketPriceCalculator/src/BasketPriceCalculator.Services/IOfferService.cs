using System.Collections.Generic;

namespace BasketPriceCalculator.Services
{
    public interface IOfferService
    {
        IList<IOffer> GetOffers();
    }

    public class OfferService : IOfferService
    {
        public IList<IOffer> GetOffers()
        {
            throw new System.NotImplementedException();
        }
    }
}