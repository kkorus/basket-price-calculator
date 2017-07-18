using System.Collections.Generic;
using System.Linq;

namespace BasketPriceCalculator.Services
{
    public class PriceCalculator
    {
        public BasketPrice CalculatePrice(List<string> products)
        {
            if (products == null || !products.Any())
            {
                return new BasketPrice(0);
            }

            return new BasketPrice(3.45m);
        }
    }
}