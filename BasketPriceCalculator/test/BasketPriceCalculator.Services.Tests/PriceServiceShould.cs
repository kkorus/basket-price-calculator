using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace BasketPriceCalculator.Services.Tests
{
    [TestFixture]
    public class PriceServiceShould
    {
        [Test]
        public void Return_Price_For_Product()
        {
            // Arrange
            var prices = new Dictionary<string, decimal>
            {
                ["milk"] = 1
            };

            var priceService = new PriceService(prices);

            // Act
            var productPrice = priceService.GetPriceFor("milk");

            // Assert
            productPrice.Should().Be(1);
        }
    }
}
