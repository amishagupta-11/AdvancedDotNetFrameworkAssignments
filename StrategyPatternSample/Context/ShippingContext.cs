using StrategyPatternSample.Interfaces;

namespace StrategyPatternSample.Context
{
    /// <summary>
    /// Represents the context for determining the shipping cost 
    /// using a specified shipping strategy.
    /// </summary>
    public class ShippingContext
    {
        private IShippingStrategy? ShippingStrategy;

        /// <summary>
        /// Sets the shipping strategy to be used for calculating the shipping cost.
        /// </summary>
        /// <param name="shippingStrategy">The shipping strategy to use.</param>
        public void SetShippingStrategy(IShippingStrategy shippingStrategy)
        {
            ShippingStrategy = shippingStrategy;
        }

        /// <summary>
        /// Calculates the shipping cost based on the provided order total 
        /// and the currently set shipping strategy.
        /// </summary>
        /// <param name="orderTotal">The total amount of the order.</param>
        /// <returns>The calculated shipping cost.</returns>
        /// <exception cref="InvalidOperationException">Thrown when no shipping strategy is set.</exception>
        public decimal GetShippingCost(decimal orderTotal)
        {
            if (ShippingStrategy == null)
            {
                throw new InvalidOperationException("Shipping Type is not found.");
            }

            return ShippingStrategy.CalculateShippingCost(orderTotal);
        }
    }
}
