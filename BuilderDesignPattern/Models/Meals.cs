namespace BuilderDesignPatternSample.Models
{
    /// <summary>
    /// The Meals class represents a complete meal with a main course, side dish, and drink.
    /// It holds the properties for these components and provides a method to display the meal's details.
    /// </summary>
    public class Meals
    {
        /// <summary>
        /// Gets or sets the main course of the meal.
        /// </summary>
        public string? MainCourse { get; set; }

        /// <summary>
        /// Gets or sets the side dish of the meal.
        /// </summary>
        public string? SideDish { get; set; }

        /// <summary>
        /// Gets or sets the drink for the meal.
        /// </summary>
        public string? Drink { get; set; }

        /// <summary>
        /// Returns a string representation of the meal, including the main course, side dish, and drink.
        /// </summary>
        /// <returns>A string that describes the meal's components.</returns>
        public override string ToString()
        {
            return $"Main Course: {MainCourse}, Side Dish: {SideDish}, Drink: {Drink}";
        }
    }
}
