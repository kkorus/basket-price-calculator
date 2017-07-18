using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasketPriceCalculator.Domain;
using FluentAssertions;
using NUnit.Framework;

namespace BasketPriceCalculator.Services.Tests
{
    [TestFixture]
    public class BasketFactoryShould
    {
        [Test]
        public void Convert_List_Of_Products_To_Basket()
        {
            // Arrange
            var expectedBasketProducts = new List<BasketProduct>
            {
                new BasketProduct("milk", 2),
                new BasketProduct("butter", 2)
            };

            var products = new List<string> { "milk", "milk", "butter", "butter" };
            var basketFactory = new BasketFactory();

            // Act
            var result = basketFactory.CreateBasket(products);

            // Assert 
            result.BasketProducts.ShouldBeEquivalentTo(expectedBasketProducts);
        }
    }
}
