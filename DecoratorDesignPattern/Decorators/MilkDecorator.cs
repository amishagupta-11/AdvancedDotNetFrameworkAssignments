using DecoratorDesignPattern.Interfaces;

namespace DecoratorDesignPattern.Decorators
{
    /// <summary>
    /// A decorator class that adds Milk to the coffee.
    /// Implements the ICoffee interface and extends the functionality of the original coffee.
    /// </summary>
    public class MilkDecorator : ICoffee
    {
        private readonly ICoffee _coffee;

        /// <summary>
        /// Initializes a new instance of the MilkDecorator class.
        /// </summary>
        /// <param name="coffee">The coffee instance to decorate with Milk.</param>
        public MilkDecorator(ICoffee coffee)
        {
            _coffee = coffee;
        }

        /// <summary>
        /// Gets the description of the coffee with the Milk decorator.
        /// This method extends the description of the coffee by adding ", Milk".
        /// </summary>
        /// <returns>The updated description of the coffee with Milk.</returns>
        public string GetDescription()
        {
            return _coffee.GetDescription() + ", Milk";
        }

        /// <summary>
        /// Calculates the cost of the coffee with the Milk decorator.
        /// This method adds 1.50 to the original coffee cost for the Milk decoration.
        /// </summary>
        /// <returns>The updated cost of the coffee with Milk.</returns>
        public double Cost()
        {
            return _coffee.Cost() + 1.50;
        }
    }
}
