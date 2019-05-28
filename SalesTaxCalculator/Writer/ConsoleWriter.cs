using System;

namespace SalesTaxCalculator.Writer
{
    public class ConsoleWriter
    {
        public void Write(Cart.Cart cart)
        {
            Console.WriteLine("------------Invoice---------------");
            foreach (var item in cart.CartItems)
            {
                Console.WriteLine("Price :" + item.Item.Price);
                Console.WriteLine("Category :" + item.Item.Category);
                Console.WriteLine("IsImported :" + item.Item.IsImported);
                Console.WriteLine("Name:" + item.Item.Name);
                Console.WriteLine("Total Cost: " + item.TotalCost);
                Console.WriteLine("Total Tax: " + item.TotalTax);
                Console.WriteLine("Quantity : " + item.Quantity);
                Console.WriteLine("---------------------------");
            }
            Console.WriteLine("TotalPrice : " + cart.TotalPrice);
            Console.WriteLine("TotalTax : " + cart.TotalTax);

        }
    }
}
