using System;

namespace BasketPriceCalculator.Services
{
    public class PriceCalculatorException : Exception
    {
        public PriceCalculatorException(string message) : base(message)
        {
            
        }
    }
}