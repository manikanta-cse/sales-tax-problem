using System;

namespace SalesTaxProblem.Policy
{
    public class RoundOffPolicy
    {
        public decimal Value
        {
            get { return 0.05m; }
        }

        public decimal RoundOffFor(decimal total)
        {
            return Math.Ceiling(total / Value) * Value;
        }
    }
}