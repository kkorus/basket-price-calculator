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

        private PriceCalculator CreatePriceCalculator()
        {
            var priceCalculator = new PriceCalculator();
            return priceCalculator;
        }
    }

}
