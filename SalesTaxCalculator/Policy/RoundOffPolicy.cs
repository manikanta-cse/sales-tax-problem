using System;

namespace SalesTaxCalculator.Policy
{
    //TODO: Need to be removed
    public class RoundOffPolicy
    {
        public decimal Value
        {
            get { return 0.05m; }
        }

        private const decimal ROUND_OFF = 0.05m;

        public virtual decimal RoundOffFor(decimal total)
        {
            return Math.Ceiling(total / ROUND_OFF) * ROUND_OFF;
        }
    }
}