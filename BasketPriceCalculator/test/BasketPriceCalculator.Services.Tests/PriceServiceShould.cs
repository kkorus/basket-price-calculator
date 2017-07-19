using System;
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

        [Test]
        public void Throw_Exception_If_Price_List_Is_Null()
        {
            // Arrange

            // Act
            Action act = () => new PriceService(null);

            // Assert 
            act.ShouldThrow<ArgumentNullException>()
                .And
                .ParamName.Should().Be("productsPrice");
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Throw_Exception_If_Product_Name_Is_Empty(string emptyProductName)
        {
            // Arrange
            var priceService = new PriceService();

            // Act
            Action act = () => priceService.GetPriceFor(emptyProductName);

            // Assert 
            act.ShouldThrow<ArgumentException>();
        }

        [Test]
        public void Throw_Exception_If_There_Is_No_Price_For_Product()
        {
            // Arrange
            var nonExistingProductPrice = "falcon 9";
            var prices = new Dictionary<string, decimal>
            {
                ["milk"] = 1
            };
            var priceServices = new PriceService(prices);

            // Act
            Action act = () => priceServices.GetPriceFor(nonExistingProductPrice);

            // Assert
            act.ShouldThrow<PriceCalculatorException>()
                .And
                .Message.Should().Contain(nonExistingProductPrice);
        }
    }
}
