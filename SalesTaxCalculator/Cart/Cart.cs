using System.Collections.Generic;
using System.Linq;
using SalesTaxCalculator.Policy;
using SalesTaxCalculator.Tax;

namespace SalesTaxCalculator.Cart
{
    public class Cart
    {
        private readonly TaxCalculator _taxCalculator;
        private readonly RoundOffPolicy _roundOffPolicy;
        public List<CartItem> CartItems { get; }

        public decimal TotalPrice
        {
            get { return CartItems.Sum(p => p.TotalCost); }
        }

        public decimal TotalTax
        {
            get { return CartItems.Sum(p => p.TotalTax); }
        }

        public Cart(TaxCalculator taxCalculator, RoundOffPolicy roundOffPolicy)
        {
            _taxCalculator = taxCalculator;
            _roundOffPolicy = roundOffPolicy;
            CartItems = new List<CartItem>();
        }

        public void Add(CartItem cartItem)
        {
            CartItems.Add(cartItem);
            var tax = _taxCalculator.Calculate(cartItem);
            SetTotalCost(cartItem, tax);
            SetTotalTax(cartItem, tax);
        }

        private void SetTotalCost(CartItem cartItem, decimal tax)
        {
            cartItem.TotalCost =
                _roundOffPolicy.RoundOffFor(cartItem.Quantity * cartItem.Item.Price) + (tax * cartItem.Quantity);
        }

        private void SetTotalTax(CartItem cartItem, decimal tax)
        {
            cartItem.TotalTax = _roundOffPolicy.RoundOffFor(tax * cartItem.Quantity);
        }


        public void Remove(CartItem cartItem)
        {
            CartItems.Remove(cartItem);
        }
    }
}
