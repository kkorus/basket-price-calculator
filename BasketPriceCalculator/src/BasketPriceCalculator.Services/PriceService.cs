using System;
using System.Collections.Generic;

namespace BasketPriceCalculator.Services
{
    public class PriceService : IPriceService
    {
        private readonly Dictionary<string, decimal> _productsPrice;

        public PriceService()
        {
            _productsPrice = new Dictionary<string, decimal>
            {
                ["butter"] = 0.8M,
                ["milk"] = 1.15M,
                ["bread"] = 1M
            };
        }

        public PriceService(Dictionary<string, decimal> productsPrice)
        {
            _productsPrice = productsPrice ?? throw new ArgumentNullException(nameof(productsPrice));
        }

        public decimal GetPriceFor(string productName)
        {
            return _productsPrice[productName];
        }

        public Dictionary<string, decimal> ProductsPrice => _productsPrice;
    }
}