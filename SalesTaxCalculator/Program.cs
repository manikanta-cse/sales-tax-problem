using System;
using System.Collections.Generic;
using System.Linq;
using SalesTaxCalculator.Cart;
using SalesTaxCalculator.Policy;
using SalesTaxCalculator.Product;
using SalesTaxCalculator.Tax;
using SalesTaxCalculator.Writer;

namespace SalesTaxCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var cart =  CartFactory.Create();

            var cartItems = new FileInputParser().Parse("input.txt");

            AddItemsToCart(cartItems, cart);

            var consoleWriter = new ConsoleWriter();
            consoleWriter.Write(cart);

            Console.ReadKey();

            //cart.Remove(cart.CartItems.First(a => a.Item.Category == ProductCategory.Books));



        }

        private static void AddItemsToCart(IEnumerable<CartItem> cartItems, Cart.Cart cart)
        {
            foreach (var cartItem in cartItems)
            {
                cart.Add(cartItem);
            }
        }
    }
}
