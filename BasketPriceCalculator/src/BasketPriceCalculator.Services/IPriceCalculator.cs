using System.Collections.Generic;

namespace BasketPriceCalculator.Services
{
    public interface IPriceCalculator
    {
        BasketPrice CalculatePrice(IList<string> products);
    }
}