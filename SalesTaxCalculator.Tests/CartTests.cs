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
        private readonly RoundOffPolicy _roundOffPolicy;
        private readonly PolicyProvider _policyProvider;

        public CartTests()
        {
            _policyProvider = Substitute.For<PolicyProvider>();
            _taxCalculator = Substitute.For<TaxCalculator>(_policyProvider);
            _roundOffPolicy = Substitute.For<RoundOffPolicy>();
           _cart = new Cart.Cart(_taxCalculator,_roundOffPolicy);
        }

        [Fact]
        public void ShouldAllowItemsToAdd()
        {
            var cartItem = new CartItem(){Item = new Product.Product(){Category = ProductCategory.Books,IsImported = false,Name = "Note Book",Price = 10}};
            _roundOffPolicy.RoundOffFor(0).Returns(0);
            _roundOffPolicy.RoundOffFor(100.04m).Returns(100.05m);
            _taxCalculator.Calculate(cartItem).Returns(0);

            _cart.Add(cartItem);

            _taxCalculator.Received().Calculate(cartItem);
            _roundOffPolicy.Received(2).RoundOffFor(Arg.Any<decimal>());

            Assert.Equal(cartItem,_cart.CartItems.First());

        }

        //[Fact]
        //public void ShouldSetTotalTax()
        //{
        //    var cartItem = new CartItem() { Item = new Product.Product() { Category = ProductCategory.Others, IsImported = false, Name = "Cosmetics", Price = 100 } ,Quantity = 1};

        //    //_roundOffPolicy.RoundOffFor(110).Returns(110);
        //    _taxCalculator.Calculate(cartItem).Returns(10.0m);
        //    //_roundOffPolicy.RoundOffFor(110).Returns(110);
        //    //_roundOffPolicy.RoundOffFor(110).Returns(110);

        //    _cart.Add(cartItem);

        //    _taxCalculator.Received().Calculate(cartItem);
        //   // _roundOffPolicy.Received(2).RoundOffFor(Arg.Any<decimal>());

        //    Assert.Equal(_cart.TotalTax,10);

        //}
    }
}
