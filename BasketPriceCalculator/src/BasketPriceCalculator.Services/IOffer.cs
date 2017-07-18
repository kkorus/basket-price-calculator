using BasketPriceCalculator.Domain;

namespace BasketPriceCalculator.Services
{
    public interface IOffer
    {
        string Name { get; set; }
        BasketProduct[] OfferProducts { get; set; }
        decimal PriceCut { get; set; }
    }
}