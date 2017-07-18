using System.Collections.Generic;

namespace BasketPriceCalculator.Domain
{
    public interface IBasket
    {
        IList<BasketProduct> BasketProducts { get; }

        void AddProduct(BasketProduct product);

        bool Contains(IEnumerable<BasketProduct> products);

        IBasket Remove(IEnumerable<BasketProduct> products);
    }
}