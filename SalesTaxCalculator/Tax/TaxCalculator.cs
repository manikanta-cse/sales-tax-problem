using SalesTaxCalculator.Cart;
using SalesTaxCalculator.Policy;

namespace SalesTaxCalculator.Tax
{
   public class TaxCalculator
    {
        private readonly PolicyProvider _policyProvider;

        public TaxCalculator(PolicyProvider policyProvider)
        {
            _policyProvider = policyProvider;
            
        }
        public virtual decimal Calculate(CartItem cartItem)
        {
            decimal tax=0;
            var applicablePolicies = _policyProvider.Get(cartItem.Item);

            foreach (var poicy in applicablePolicies)
            {
                 tax += (cartItem.Item.Price * poicy.TaxRate) / 100;
                 
            }
            return tax;            
        }

       
    }
}
