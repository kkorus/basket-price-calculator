using System;
using System.Collections.Generic;
using Autofac;
using BasketPriceCalculator.Services;

namespace BasketPriceCalculator.App
{
    class Program
    {
        static void Main()
        {
            IContainer container = BuildContainer();
            IPriceCalculator priceCalculator = container.Resolve<IPriceCalculator>();
            IList<string> products = GetProductsFromConsole();

            BasketPrice basketPrice;

            try
            {
                basketPrice = priceCalculator.CalculatePrice(products);
            }
            catch (PriceCalculatorException e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            Console.WriteLine($"Total price: {basketPrice.Price:C}");
        }

        private static IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<PriceCalculator>().As<IPriceCalculator>();
            builder.RegisterType<PriceService>().As<IPriceService>();
            builder.RegisterType<OfferService>().As<IOfferService>();
            builder.RegisterType<DiscountCalculator>().As<IDiscountCalculator>();
            builder.RegisterType<BasketFactory>().As<IBasketFactory>();

            return builder.Build();
        }

        private static IList<string> GetProductsFromConsole()
        {
            Console.WriteLine("Please choose products you want to buy:");
            var selectedProducts = new List<string>();

            string product;
            while (!string.IsNullOrWhiteSpace(product = Console.ReadLine()))
            {
                selectedProducts.Add(product.ToLower().Trim());
            }

            return selectedProducts;
        }
    }
}
