﻿using StrategyPatternSample.Interfaces;

namespace StrategyPatternSample.Strategies
{
    /// <summary>
    /// Represents a shipping strategy for Standard shipping,
    /// calculating the shipping cost as a percentage of the order total.
    /// </summary>
    public class StandardShippingStrategy : IShippingStrategy
    {
        /// <summary>
        /// Calculates the shipping cost for standard shipping 
        /// based on the given order total.
        /// </summary>
        /// <param name="orderTotal">The total amount of the order.</param>
        /// <returns>The calculated shipping cost.</returns>
        public decimal CalculateShippingCost(decimal orderTotal)
        {
            return 5.00m; 
        }
    }
}