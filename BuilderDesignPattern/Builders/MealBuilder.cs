using BuilderDesignPatternSample.Interfaces;
using BuilderDesignPatternSample.Models;

namespace BuilderDesignPatternSample.Builders
{
    /// <summary>
    /// A concrete implementation of the <see cref="IMealBuilder"/> interface.
    /// This builder is responsible for constructing a <see cref="Meals"/> object step by step.
    /// </summary>
    public class MealBuilder : IMealBuilder
    {
        private readonly Meals Meal;

        /// <summary>
        /// Initializes a new instance of the <see cref="MealBuilder"/> class.
        /// This constructor creates a new <see cref="Meals"/> object that will be built.
        /// </summary>
        public MealBuilder()
        {
            Meal = new Meals();
        }

        /// <summary>
        /// Adds a main course to the meal.
        /// </summary>
        /// <param name="mainCourse">The main course to be added to the meal.</param>
        /// <returns>The current instance of the builder to allow method chaining.</returns>
        public IMealBuilder AddMainCourse(string mainCourse)
        {
            Meal.MainCourse = mainCourse;
            return (IMealBuilder)this;
        }

        /// <summary>
        /// Adds a side dish to the meal.
        /// </summary>
        /// <param name="sideDish">The side dish to be added to the meal.</param>
        /// <returns>The current instance of the builder to allow method chaining.</returns>
        public IMealBuilder AddSideDish(string sideDish)
        {
            Meal.SideDish = sideDish;
            return (IMealBuilder)this;
        }

        /// <summary>
        /// Adds a drink to the meal.
        /// </summary>
        /// <param name="drink">The drink to be added to the meal.</param>
        /// <returns>The current instance of the builder to allow method chaining.</returns>
        public IMealBuilder AddDrink(string drink)
        {
            Meal.Drink = drink;
            return (IMealBuilder)this;
        }

        /// <summary>
        /// Builds and returns the constructed meal.
        /// </summary>
        /// <returns>The fully constructed <see cref="Meals"/> object representing the meal.</returns>
        public Meals Build()
        {
            return Meal;
        }
    }
}
