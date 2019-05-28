using System.Collections.Generic;
using SalesTaxCalculator.Product;

namespace SalesTaxCalculator.Policy
{
    public class PolicyProvider
    {
        public IEnumerable<Policy> Get(Product.Product product)
        {
            var applicablePoclies = new List<Policy>();
            switch (product.Category)
            {
                case ProductCategory.Food:
                    applicablePoclies.Add(new Policy() { TaxRate = 0, Type = PolicyCategory.FoodSalesTaxPolicy });
                    break;
                case ProductCategory.Books:
                    applicablePoclies.Add(new Policy() { TaxRate = 0, Type = PolicyCategory.BooksSalesTaxPolicy });
                    break;
                case ProductCategory.Medicines:
                    applicablePoclies.Add(new Policy() { TaxRate = 0, Type = PolicyCategory.MedicinesSalesTaxPolicy });
                    break;
                default:
                    applicablePoclies.Add(new Policy() { TaxRate = 10.00M, Type = PolicyCategory.NonExemptedSalesTaxPolicy });
                    break;
            }

            if (product.IsImported)
            {
                applicablePoclies.Add(new Policy() { TaxRate = 5.00M, Type = PolicyCategory.ImportedDutySalesTaxPolicy });
            }

            return applicablePoclies;
        }
       
    }
}
