namespace SalesTaxProblem.Cart
{
    public class CartItem
    {
        public Product.Product Item { get; set; }

        public int Quantity { get; set; }

        public decimal TotalCost { get; set; }
        public decimal TotalTax { get; set; }



    }
}
