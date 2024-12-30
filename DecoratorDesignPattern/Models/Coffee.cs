using DecoratorDesignPattern.Interfaces;

namespace DecoratorDesignPattern.Models
{
    /// <summary>
    /// Represents a basic coffee with no decorators.
    /// Implements the ICoffee interface to provide description and cost.
    /// </summary>
    public class Coffee : ICoffee
    {
        /// <summary>
        /// Gets the description of the basic coffee.
        /// This method provides the name of the coffee type without any decorators.
        /// </summary>
        /// <returns>A string that describes the basic coffee.</returns>
        public string GetDescription()
        {
            return "Basic Coffee";
        }

        /// <summary>
        /// Calculates the cost of the basic coffee.
        /// This method returns the base cost of a plain coffee without any added decorators.
        /// </summary>
        /// <returns>The cost of the basic coffee.</returns>
        public double Cost()
        {
            return 5.00;
        }
    }
}
