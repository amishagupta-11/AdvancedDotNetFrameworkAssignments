namespace StrategyPatternSample.Interfaces
{
    /// <summary>
    /// Defines the contract for a shipping strategy 
    /// to calculate shipping costs based on an order total.
    /// </summary>
    public interface IShippingStrategy
    {
        /// <summary>
        /// Calculates the shipping cost for a given order total.
        /// </summary>
        /// <param name="orderTotal">The total amount of the order.</param>
        /// <returns>The calculated shipping cost.</returns>
        decimal CalculateShippingCost(decimal orderTotal);
    }
}
