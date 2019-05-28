using System;
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
            var policyProvider = new PolicyProvider();
            var taxCalculator = new TaxCalculator(policyProvider);
            //var roundOffPolicy = new RoundOffPolicy();


            var cart = new Cart.Cart(taxCalculator);

            cart.Add(new CartItem()
            {
                Item = new Product.Product { Category = ProductCategory.Food, IsImported = false, Name = "Chocolates", Price = 5 },
                Quantity = 1

            });
            cart.Add(new CartItem()
            {
                Item = new Product.Product { Category = ProductCategory.Books, IsImported = false, Name = "Clean Coder By Martin", Price = 550 },
                Quantity = 1,

            });
            cart.Add(new CartItem()
            {
                Item = new Product.Product { Category = ProductCategory.Medicines, IsImported = true, Name = "Tab Ooo", Price = 100 },
                Quantity = 2
            });

            cart.Add(new CartItem()
            {
                Item = new Product.Product { Category = ProductCategory.Others, IsImported = true, Name = "Perfume", Price = 100.02m },
                Quantity = 2
            });


            var consoleWriter = new ConsoleWriter();
            consoleWriter.Write(cart);


            //cart.Remove(cart.CartItems.First(a=>a.Item.Category== ProductCategory.Books));

            //new ConsoleWriter().Write(cart);

            Console.ReadKey();





        }


    }
}
