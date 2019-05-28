using System;
using System.Collections.Generic;
using System.Linq;
using SalesTaxCalculator.Policy;
using SalesTaxCalculator.Tax;

namespace SalesTaxCalculator.Cart
{
    public class Cart
    {
        private readonly TaxCalculator _taxCalculator;
        public List<CartItem> CartItems { get; }

        private const decimal ROUND_OFF = 0.05m;

        public decimal TotalPrice
        {
            get { return RoundOffFor(CartItems.Sum(p => p.TotalPrice)); }
        }

        public decimal TotalTax
        {
            get { return CartItems.Sum(p => p.TotalTax); }
        }

        public Cart(TaxCalculator taxCalculator)
        {
            _taxCalculator = taxCalculator;
            CartItems = new List<CartItem>();
        }

        public void Add(CartItem cartItem)
        {
            CartItems.Add(cartItem);
            var tax = _taxCalculator.Calculate(cartItem);
            SetTotalCost(cartItem, _taxCalculator.Calculate(cartItem));
            SetTotalTax(cartItem, tax);
        }

        public void Remove(CartItem cartItem)
        {
            CartItems.Remove(cartItem);
        }

        private void SetTotalCost(CartItem cartItem, decimal tax)
        {
            cartItem.TotalPrice = (cartItem.Quantity * cartItem.Item.Price) + (tax * cartItem.Quantity);
        }

        private void SetTotalTax(CartItem cartItem, decimal tax)
        {
            cartItem.TotalTax = (tax * cartItem.Quantity);
        }

        private decimal RoundOffFor(decimal totalPrice)
        {
            return Math.Ceiling(totalPrice / ROUND_OFF) * ROUND_OFF;
        }
    }
}
