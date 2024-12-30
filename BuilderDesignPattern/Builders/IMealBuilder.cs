using BuilderDesignPatternSample.Models;

namespace BuilderDesignPatternSample.Interfaces
{
    /// <summary>
    /// Defines the interface for a builder that constructs a meal with a main course, side dish, and drink.
    /// </summary>
    public interface IMealBuilder
    {
        /// <summary>
        /// Adds a main course to the meal.
        /// </summary>
        /// <param name="mainCourse">The main course to be added to the meal.</param>
        /// <returns>The current instance of the builder to allow method chaining.</returns>
        public IMealBuilder AddMainCourse(string mainCourse);

        /// <summary>
        /// Adds a side dish to the meal.
        /// </summary>
        /// <param name="sideDish">The side dish to be added to the meal.</param>
        /// <returns>The current instance of the builder to allow method chaining.</returns>
        public IMealBuilder AddSideDish(string sideDish);

        /// <summary>
        /// Adds a drink to the meal.
        /// </summary>
        /// <param name="drink">The drink to be added to the meal.</param>
        /// <returns>The current instance of the builder to allow method chaining.</returns>
        public IMealBuilder AddDrink(string drink);

        /// <summary>
        /// Builds and returns the constructed meal.
        /// </summary>
        /// <returns>The fully constructed <see cref="Meals"/> object representing the meal.</returns>
        public Meals Build();
    }
}
