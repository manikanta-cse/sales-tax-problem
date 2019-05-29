using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using SalesTaxCalculator.Cart;
using SalesTaxCalculator.Product;

namespace SalesTaxCalculator
{
    public class FileInputParser
    {
        private const char SEPERATOR = ' ';
        public IEnumerable<CartItem> Parse(string filename)
        {
            var inputLines = File.ReadAllLines(filename);

            var cartitems = new List<CartItem>();

            foreach (var line in inputLines)
            {
                cartitems.Add(ParseCartItem(line));
            }

            return cartitems;
        }

        private CartItem ParseCartItem(string line)
        {
            return new CartItem
            {
                Item = new Product.Product()
                {
                    IsImported = IsImported(line),
                    Price = GetItemPrice(GetItemDetails(line)),
                    Name = GetItemName(GetItemDetails(line)),
                    Category = GetCategory(GetItemDetails(line))
                   
                },Quantity = GetQuantity(GetItemDetails(line))
            };
        }

        private int GetQuantity(IEnumerable<string> itemDetails)
        {
            return Convert.ToInt32(itemDetails.ElementAt(0));
        }

        private ProductCategory GetCategory(IEnumerable<string> itemDetails)
        {
            switch (GetItemName(itemDetails))
            {
                case "book" :
                case "books":
                    return ProductCategory.Books;

                case "chocolates":
                case "chocolate" :
                case "bar":
                    return ProductCategory.Food;
                case "medicines":
                case "medicine":
                    return ProductCategory.Medicines;
                default:
                    return ProductCategory.Others;
            }
        }

        private IEnumerable<string> GetItemDetails(string line)
        {
            return line.Split(SEPERATOR);
        }

        private decimal GetItemPrice(IEnumerable<string> itemDetails)
        {
            return Convert.ToDecimal(itemDetails.ElementAt(itemDetails.Count()-1));
        }

        private string GetItemName(IEnumerable<string> itemDetails)
        {
            return itemDetails.ElementAt(itemDetails.Count()-3);
        }

        private bool IsImported(string line)
        {
            return line.Contains("imported");
        }
    }
}
