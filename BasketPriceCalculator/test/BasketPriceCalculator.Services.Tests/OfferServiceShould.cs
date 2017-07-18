using BasketPriceCalculator.Domain;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace BasketPriceCalculator.Services.Tests
{
    [TestFixture]
    public class OfferServiceShould
    {
        private Mock<IPriceService> _priceService;

        private OfferService _offerService;

        [SetUp]
        public void SetUp()
        {
            _priceService = new Mock<IPriceService>();
            _offerService = new OfferService(_priceService.Object);
        }

        [Test]
        public void Return_Offers()
        {
            // Arrange
            _priceService.Setup(x => x.GetPriceFor("milk")).Returns(1.15m);
            _priceService.Setup(x => x.GetPriceFor("bread")).Returns(1);

            var exoectedOffers = new[] { CreateButterAndBreadOffer(), CreateMilkOffer() };

            // Act
            var offers = _offerService.GetOffers();

            // Assert
            offers.ShouldBeEquivalentTo(exoectedOffers);
        }

        private Offer CreateMilkOffer()
        {
            return new Offer
            {
                Name = "Buy 3 Milk and get the 4th milk for free",
                OfferProducts = new[] { new BasketProduct("milk", 4) },
                PriceCut = 1.15m
            };
        }

        private Offer CreateButterAndBreadOffer()
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
