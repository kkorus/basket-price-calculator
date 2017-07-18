using BasketPriceCalculator.Domain;

namespace BasketPriceCalculator.Services
{
    public class Offer : IOffer
    {
        public string Name { get; set; }
        public BasketProduct[] OfferProducts { get; set; }
        public decimal PriceCut { get; set; }
    }
}