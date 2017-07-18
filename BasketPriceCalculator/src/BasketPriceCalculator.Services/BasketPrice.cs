namespace BasketPriceCalculator.Services
{
    public class BasketPrice
    {
        public decimal Price { get; }

        public BasketPrice(decimal price)
        {
            Price = price;
        }
    }
}