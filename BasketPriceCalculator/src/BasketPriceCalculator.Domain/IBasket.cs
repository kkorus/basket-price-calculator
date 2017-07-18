using System.Collections.Generic;

namespace BasketPriceCalculator.Domain
{
    public interface IBasket
    {
        IList<BasketProduct> BasketProducts { get; }
    }
}