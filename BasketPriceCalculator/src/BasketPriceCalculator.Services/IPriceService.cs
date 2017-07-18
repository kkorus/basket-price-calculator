namespace BasketPriceCalculator.Services
{
    public interface IPriceService
    {
        decimal GetPriceFor(string productName);
    }
}