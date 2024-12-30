using DecoratorDesignPattern.Interfaces;

namespace DecoratorDesignPattern.Decorators
{
    /// <summary>
    /// A decorator class that adds Sugar to the coffee.
    /// Implements the ICoffee interface and extends the functionality of the original coffee.
    /// </summary>
    public class SugarDecorator : ICoffee
    {
        private readonly ICoffee _coffee;

        /// <summary>
        /// Initializes a new instance of the SugarDecorator class.
        /// </summary>
        /// <param name="coffee">The coffee instance to decorate with Sugar.</param>
        public SugarDecorator(ICoffee coffee)
        {
            _coffee = coffee;
        }

        /// <summary>
        /// Gets the description of the coffee with the Sugar decorator.
        /// This method extends the description of the coffee by adding ", Sugar".
        /// </summary>
        /// <returns>The updated description of the coffee with Sugar.</returns>
        public string GetDescription()
        {
            return _coffee.GetDescription() + ", Sugar";
        }

        /// <summary>
        /// Calculates the cost of the coffee with the Sugar decorator.
        /// This method adds 0.75 to the original coffee cost for the Sugar decoration.
        /// </summary>
        /// <returns>The updated cost of the coffee with Sugar.</returns>
        public double Cost()
        {
            return _coffee.Cost() + 0.75;
        }
    }
}
