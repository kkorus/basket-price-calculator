using System.Collections.Generic;
using NUnit.Framework;

namespace BasketPriceCalculator.Services.Tests
{
    [TestFixture]
    public class PriceCalculatorFeature
    {
        [Test]
        public void Calculate_Price_Returns_0_For_No_Products()
        {
            // Arrange
            var products = new List<string>();
            var priceCalculator = CreatePriceCalculator();

            // Act
            var result = priceCalculator.CalculatePrice(products);

            // Assert
            Assert.That(result.Price, Is.EqualTo(0));
        }

        [Test]
        public void Calculate_Price_For_Products_List()
        {
            // Arrange
            var products = new List<string> { "milk", "milk", "milk", "milk" };
            var priceCalculator = CreatePriceCalculator();

            // Act
            var result = priceCalculator.CalculatePrice(products);

            // Assert
            Assert.That(result.Price, Is.EqualTo(3.45));
        }

        private PriceCalculator CreatePriceCalculator()
        {
            IBasketFactory basketFactory = new BasketFactory();
            IOfferService offerService = new OfferService();
            IDiscountCalculator discountCalculator = new DiscountCalculator(offerService);
            var priceCalculator = new PriceCalculator(basketFactory, discountCalculator);
            return priceCalculator;
        }
    }
}
