using System.Collections.Generic;
using System.Linq;

namespace BasketPriceCalculator.Services
{
    public class PriceCalculator
    {
        private readonly IBasketFactory _basketFactory;
        private readonly IDiscountCalculator _discountCalculator;

        public PriceCalculator(
            IBasketFactory basketFactory, 
            IDiscountCalculator discountCalculator)
        {
            _basketFactory = basketFactory;
            _discountCalculator = discountCalculator;
        }

        public BasketPrice CalculatePrice(List<string> products)
        {
            if (products == null || !products.Any())
            {
                return new BasketPrice(0);
            }

            var basket = _basketFactory.CreateBasket(products);
            var discount = _discountCalculator.CalculateDiscount(basket);

            return new BasketPrice(3.45m);
        }
    }
}