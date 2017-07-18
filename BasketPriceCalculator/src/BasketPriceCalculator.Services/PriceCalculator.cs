using System.Collections.Generic;

namespace BasketPriceCalculator.Services
{
    public class PriceCalculator
    {
        public BasketPrice CalculatePrice(List<string> products)
        {
            return new BasketPrice(0);
        }
    }
}