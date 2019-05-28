using System;

namespace SalesTaxCalculator.Policy
{
    public class RoundOffPolicy
    {
        public decimal Value
        {
            get { return 0.05m; }
        }

        public virtual decimal RoundOffFor(decimal total)
        {
            return Math.Ceiling(total / Value) * Value;
        }
    }
}