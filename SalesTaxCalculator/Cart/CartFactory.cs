using SalesTaxCalculator.Tax;
using System;
using System.Collections.Generic;
using System.Text;
using SalesTaxCalculator.Policy;

namespace SalesTaxCalculator.Cart
{
   public class CartFactory
    {
        public static Cart Create()
        {
            var policyProvider = new PolicyProvider();
            var taxCalculator = new TaxCalculator(policyProvider);

            return new Cart(taxCalculator);
        }
    }
}
