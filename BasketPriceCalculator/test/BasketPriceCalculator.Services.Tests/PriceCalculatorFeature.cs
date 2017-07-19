using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
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

        [Test, TestCaseSource(nameof(_calculatePriceCases))]
        public void Calculate_Price_For_Products_List(string[] products, decimal expectedPrice)
        {
            // Arrange
            var priceCalculator = CreatePriceCalculator();

            // Act
            var result = priceCalculator.CalculatePrice(products.ToList());

            // Assert
            result.Price.Should().Be(expectedPrice);
        }

        static object[] _calculatePriceCases =
        {
            new object[] { new[] { "bread", "butter", "milk"}, 2.95M},
            new object[] { new[] { "butter", "butter", "bread", "bread"}, 3.1M},
            new object[] { new[] { "milk", "milk", "milk", "milk"}, 3.45M},
            new object[] { new[] { "butter", "butter", "bread", "milk", "milk", "milk", "milk", "milk", "milk", "milk", "milk" }, 9M}
        };

        private PriceCalculator CreatePriceCalculator()
        {
            IBasketFactory basketFactory = new BasketFactory();
            IPriceService priceService = new PriceService();
            IOfferService offerService = new OfferService(priceService);
            IDiscountCalculator discountCalculator = new DiscountCalculator(offerService);
            var priceCalculator = new PriceCalculator(basketFactory, discountCalculator, priceService);
            return priceCalculator;
        }
    }
}
