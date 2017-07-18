using System.Collections.Generic;

namespace BasketPriceCalculator.Domain
{
    public class Basket : IBasket
    {
        public Basket(IList<BasketProduct> basketProducts)
        {
            BasketProducts = basketProducts;
        }

        public IList<BasketProduct> BasketProducts { get; }
    }
}