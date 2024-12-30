namespace DecoratorDesignPattern.Interfaces
{
    /// <summary>
    /// Defines the contract for a Coffee object.
    /// Implementing classes should provide a description of the coffee and calculate its cost.
    /// </summary>
    public interface ICoffee
    {
        /// <summary>
        /// Gets the description of the coffee.
        /// This method should return a string that describes the type of coffee.
        /// </summary>
        /// <returns>A string describing the coffee.</returns>
        public string GetDescription();

        /// <summary>
        /// Calculates the cost of the coffee.
        /// This method should return the cost of the coffee, considering any decorators applied.
        /// </summary>
        /// <returns>The cost of the coffee.</returns>
        public double Cost();
    }
}
