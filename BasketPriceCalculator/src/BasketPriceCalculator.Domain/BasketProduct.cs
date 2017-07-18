namespace BasketPriceCalculator.Domain
{
    public class BasketProduct
    {
        public BasketProduct(string productName, int quanity)
        {
            ProductName = productName;
            Quanity = quanity;
        }

        public string ProductName { get; }

        public int Quanity { get; }
    }
}