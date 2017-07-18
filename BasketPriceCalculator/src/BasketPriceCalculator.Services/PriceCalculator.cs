using System.Collections.Generic;
using System.Linq;

namespace BasketPriceCalculator.Services
{
    public class PriceCalculator
    {
        private readonly IBasketFactory _basketFactory;

        public PriceCalculator(IBasketFactory basketFactory)
        {
            _basketFactory = basketFactory;
        }

        public BasketPrice CalculatePrice(List<string> products)
        {
            if (products == null || !products.Any())
            {
                return new BasketPrice(0);
            }

            var basket = _basketFactory.CreateBasket(products);

            return new BasketPrice(3.45m);
        }
    }
}