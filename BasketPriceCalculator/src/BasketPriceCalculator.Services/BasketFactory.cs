using System;
using System.Collections.Generic;
using System.Linq;
using BasketPriceCalculator.Domain;

namespace BasketPriceCalculator.Services
{
    public class BasketFactory : IBasketFactory
    {
        public IBasket CreateBasket(List<string> products)
        {
            if (products == null)
                throw new ArgumentNullException(nameof(products));

            var basketProducts = products.GroupBy(x => x).Select(x => new BasketProduct(x.Key, x.Count())).ToList();
            return new Basket(basketProducts);
        }
    }
}