using System;
using System.Collections.Generic;
using System.Linq;

namespace BasketPriceCalculator.Domain
{
    public class Basket : IBasket
    {
        public IList<BasketProduct> BasketProducts { get; }

        public Basket()
        {
            BasketProducts = new List<BasketProduct>();
        }

        public Basket(IList<BasketProduct> basketProducts)
        {
            BasketProducts = basketProducts;
        }

        public void AddProduct(BasketProduct product)
        {
            BasketProducts.Add(product);
        }

        public bool Contains(IEnumerable<BasketProduct> products)
        {
            if (products == null || !products.Any())
            {
                throw new ArgumentException(nameof(products));
            }

            return products.All(product =>
            {
                var basketContainsProducts = BasketProducts.Any(x =>
                    x.ProductName == product.ProductName &&
                    x.Quanity >= product.Quanity);
                return basketContainsProducts;
            });
        }

        public IBasket Remove(IEnumerable<BasketProduct> products)
        {
            if (products == null || !products.Any())
            {
                throw new ArgumentException(nameof(products));
            }

            if (!Contains(products))
            {
                throw new ArgumentException("Basket doesn't contains those products.");
            }

            var newBasket = new Basket();

            foreach (var basketProduct in BasketProducts)
            {
                var productToRemove = products.SingleOrDefault(x => x.ProductName == basketProduct.ProductName);
                if (productToRemove != null)
                {
                    var quanity = basketProduct.Quanity - productToRemove.Quanity;
                    if (quanity > 0)
                    {
                        newBasket.AddProduct(new BasketProduct(basketProduct.ProductName, quanity));
                    }
                }
                else
                {
                    newBasket.AddProduct(basketProduct);
                }
            }

            return newBasket;
        }
    }
}