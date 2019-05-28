namespace SalesTaxCalculator.Product
{
    public class Product
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public bool IsImported { get; set; }

        public ProductCategory Category { get; set; }

    }
}
