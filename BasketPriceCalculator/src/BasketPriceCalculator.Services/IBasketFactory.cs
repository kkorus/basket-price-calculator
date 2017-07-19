using System.Collections.Generic;
using BasketPriceCalculator.Domain;

namespace BasketPriceCalculator.Services
{
    public interface IBasketFactory
    {
        IBasket CreateBasket(IList<string> products);
    }
}