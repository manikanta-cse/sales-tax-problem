using SalesTaxCalculator.Cart;
using System;
using System.Linq;
using NSubstitute;
using SalesTaxCalculator.Policy;
using SalesTaxCalculator.Product;
using SalesTaxCalculator.Tax;
using Xunit;

namespace SalesTaxCalculator.Tests
{
    public class CartTests
    {
        private readonly Cart.Cart _cart;
        private readonly TaxCalculator _taxCalculator;
        private readonly PolicyProvider _policyProvider;

        public CartTests()
        {
            _policyProvider = Substitute.For<PolicyProvider>();
            _taxCalculator = Substitute.For<TaxCalculator>(_policyProvider);
            _cart = new Cart.Cart(_taxCalculator);
        }

        [Fact]
        public void ShouldAllowItemsToAdd()
        {
            var cartItem = new CartItem(){Item = new Product.Product(){Category = ProductCategory.Books,IsImported = false,Name = "Note Book",Price = 10}};
            _taxCalculator.Calculate(cartItem).Returns(0);

            _cart.Add(cartItem);

            _taxCalculator.Received().Calculate(cartItem);

            Assert.Equal(cartItem,_cart.CartItems.First());

        }

        [Fact]
        public void ShouldSetTotalTax()
        {
            var cartItem = new CartItem() { Item = new Product.Product() { Category = ProductCategory.Others, IsImported = false, Name = "Cosmetics", Price = 100 }, Quantity = 1 };
         
            _taxCalculator.Calculate(cartItem).Returns(10.0m);

            _cart.Add(cartItem);

            _taxCalculator.Received().Calculate(cartItem);

            Assert.Equal(10, _cart.TotalTax);

        }

        [Fact]
        public void ShouldSetTotalCost()
        {
            var cartItem = new CartItem() { Item = new Product.Product() { Category = ProductCategory.Others, IsImported = false, Name = "Cosmetics", Price = 100 }, Quantity = 1 };

            _taxCalculator.Calculate(cartItem).Returns(10.0m);

            _cart.Add(cartItem);

            _taxCalculator.Received().Calculate(cartItem);

            Assert.Equal(110, _cart.TotalPrice);

        }
    }
}
