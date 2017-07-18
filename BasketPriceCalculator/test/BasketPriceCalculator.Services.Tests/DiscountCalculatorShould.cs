using System.Collections.Generic;
using BasketPriceCalculator.Domain;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace BasketPriceCalculator.Services.Tests
{
    [TestFixture]
    public class DiscountCalculatorShould
    {
        private Mock<IOfferService> _offerService;
        private DiscountCalculator _discountCalculator;

        [SetUp]
        public void SetUp()
        {
            _offerService = new Mock<IOfferService>();
            _discountCalculator = new DiscountCalculator(_offerService.Object);
        }

        [TearDown]
        public void TearDown()
        {
            _offerService.Reset();
        }

        [Test]
        public void Calculate_Discount_For_Basket_When_There_Is_One_Offer()
        {
            // Arrange
            _offerService.Setup(x => x.GetOffers()).Returns(new IOffer[] { CreateButterAndBreadOffer() });

            var basketProducts = new List<BasketProduct>
            {
                new BasketProduct("butter", 2),
                new BasketProduct("bread", 1)
            };

            var basket = new Basket(basketProducts);

            var expectedDiscount = new Discount(0.5m);

            // Act
            var discount = _discountCalculator.CalculateDiscount(basket);

            // Assert 
            discount.Value.Should().Be(expectedDiscount.Value);
        }

        private static Offer CreateButterAndBreadOffer()
        {
            return new Offer
            {
                Name = "Buy 2 Butter and get a Bread at 50% off",
                OfferProducts = new[] { new BasketProduct("butter", 2), new BasketProduct("bread", 1) },
                PriceCut = 0.5m
            };
        }
    }
}