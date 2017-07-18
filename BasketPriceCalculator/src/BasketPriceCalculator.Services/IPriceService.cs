using System;

namespace BasketPriceCalculator.Services
{
    public interface IPriceService
    {
        decimal GetPriceFor(string productName);
    }

    public class PriceService : IPriceService
    {
        public decimal GetPriceFor(string productName)
        {
            throw new NotImplementedException();
        }
    }
}