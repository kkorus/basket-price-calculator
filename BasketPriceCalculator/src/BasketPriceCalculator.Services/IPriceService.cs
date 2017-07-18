using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
