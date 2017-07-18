using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace BasketPriceCalculator.Domain.Tests
{
    [TestFixture]
    public class BasketShould
    {
        private BasketBuilder _basketBuilder;

        [SetUp]
        public void SetUp()
        {
            _basketBuilder = new BasketBuilder();
        }

        [Test]
        public void Return_Empty_Basket_When_Created_With_No_Products()
        {
            // Arrange

            // Act
            var basket = new Basket();

            // Assert
            basket.BasketProducts.Should().BeEmpty();
        }

        [Test]
        public void Add_Product_To_Basket()
        {
            // Arrange
            var basketProduct = new BasketProduct("milk", 1);
            var basket = new Basket();

            // Act
            basket.AddProduct(basketProduct);

            // Assert
            basket.BasketProducts.Count.Should().Be(1);
            basket.BasketProducts[0].ProductName.Should().Be(basketProduct.ProductName);
            basket.BasketProducts[0].Quanity.Should().Be(basketProduct.Quanity);
        }

        [Test]
        public void Return_True_When_Contains_Products()
        {
            // Arrange
            var basket = _basketBuilder
                .WithProduct("milk", 2)
                .WithProduct("butter", 1)
                .Build();

            var products = new[] { new BasketProduct("butter", 1) };

            // Act
            var contains = basket.Contains(products);

            // Assert
            contains.Should().BeTrue();
        }

        [Test]
        public void Return_False_When_Doesnt_Contains_Products()
        {
            // Arrange
            var basket = _basketBuilder
                .WithProduct("milk", 2)
                .WithProduct("butter", 1)
                .Build();

            var products = new[] { new BasketProduct("bread", 1) };

            // Act
            var contains = basket.Contains(products);

            // Assert
            contains.Should().BeFalse();
        }

        [Test]
        public void Remove_Products_When_Contains_Products_To_Remove()
        {
            // Arrange
            var basket = _basketBuilder
                .WithProduct("milk", 2)
                .WithProduct("butter", 1)
                .Build();

            var productsToRemove = new[] { new BasketProduct("milk", 2) };

            // Act
            var newBasket = basket.Remove(productsToRemove);

            // Assert
            newBasket.BasketProducts.Count.Should().Be(1);
            newBasket.BasketProducts[0].ProductName.Should().Be("butter");
            newBasket.BasketProducts[0].Quanity.Should().Be(1);
        }

        [Test]
        public void Throw_Exception_When_Doesnt_Contains_Products_To_Remove()
        {
            // Arrange
            var basket = _basketBuilder
                .WithProduct("milk", 2)
                .WithProduct("butter", 1)
                .Build();

            var productsToRemove = new[] { new BasketProduct("soup", 1) };

            // Act
            Action act = () => basket.Remove(productsToRemove);

            // Assert
            act.ShouldThrow<ArgumentException>()
                .And
                .Message.Should().Be("Basket doesn't contains those products.");
        }
    }

    public class BasketBuilder
    {
        private readonly IList<BasketProduct> _products;

        public BasketBuilder()
        {
            _products = new List<BasketProduct>();
        }

        public BasketBuilder WithProduct(string productName, int quanity)
        {
            _products.Add(new BasketProduct(productName, quanity));
            return this;
        }

        public Basket Build()
        {
            return new Basket(_products);
        }
    }
}
