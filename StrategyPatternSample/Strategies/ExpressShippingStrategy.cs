using StrategyPatternSample.Interfaces;

namespace StrategyPatternSample.Strategies
{
    /// <summary>
    /// Represents a shipping strategy for express shipping,
    /// calculating the shipping cost as a percentage of the order total.
    /// </summary>
    public class ExpressShippingStrategy : IShippingStrategy
    {
        /// <summary>
        /// Calculates the shipping cost for express shipping 
        /// based on the given order total.
        /// </summary>
        /// <param name="orderTotal">The total amount of the order.</param>
        /// <returns>The calculated shipping cost.</returns>
        public decimal CalculateShippingCost(decimal orderTotal)
        {
            // 10% of the order total
            return orderTotal * 0.1m; 
        }
    }
}
