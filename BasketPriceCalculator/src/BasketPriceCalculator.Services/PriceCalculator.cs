using System.Collections.Generic;
using System.Linq;
using BasketPriceCalculator.Domain;

namespace BasketPriceCalculator.Services
{
    public class PriceCalculator : IPriceCalculator
    {
        private readonly IBasketFactory _basketFactory;
        private readonly IDiscountCalculator _discountCalculator;
        private readonly IPriceService _priceService;

        public PriceCalculator(
            IBasketFactory basketFactory,
            IDiscountCalculator discountCalculator,
            IPriceService priceService)
        {
            _basketFactory = basketFactory;
            _discountCalculator = discountCalculator;
            _priceService = priceService;
        }

        public BasketPrice CalculatePrice(List<string> products)
        {
            if (products == null || !products.Any())
            {
                return new BasketPrice(0);
            }

            var basket = _basketFactory.CreateBasket(products);
            var discount = _discountCalculator.CalculateDiscount(basket);

            var basketPrice = CalculateBasketPriceWithDiscount(basket, discount);
            return basketPrice;
        }

        private BasketPrice CalculateBasketPriceWithDiscount(IBasket basket, Discount discount)
        {
            var total = 0M;
            foreach (var basketBasketProduct in basket.BasketProducts)
            {
                total += basketBasketProduct.Quanity *
                         _priceService.GetPriceFor(basketBasketProduct.ProductName);
            }

            return new BasketPrice(total - discount.Value);
        }
    }
}