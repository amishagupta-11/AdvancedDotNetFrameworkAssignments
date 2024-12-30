using DecoratorDesignPattern.Interfaces;

namespace DecoratorDesignPattern.Models
{
    /// <summary>
    /// Represents an Espresso coffee.
    /// Implements the ICoffee interface to provide description and cost.
    /// </summary>
    public class Espresso : ICoffee
    {
        /// <summary>
        /// Gets the description of the Espresso coffee.
        /// This method provides the name of the coffee type (Espresso).
        /// </summary>
        /// <returns>A string that describes the Espresso coffee.</returns>
        public string GetDescription()
        {
            return "Espresso";
        }

        /// <summary>
        /// Calculates the cost of the Espresso coffee.
        /// This method returns the base cost of an Espresso without any added decorators.
        /// </summary>
        /// <returns>The cost of the Espresso coffee.</returns>
        public double Cost()
        {
            return 3.00;
        }
    }
}
