using BuilderDesignPatternSample.Interfaces;
using BuilderDesignPatternSample.Models;

namespace BuilderDesignPatternSample.Directors
{
    /// <summary>
    /// The MealDirector class is responsible for constructing specific types of meals using the builder pattern.
    /// It abstracts the construction process of different meals and ensures that the right combination of 
    /// ingredients (main course, side dish, and drink) are selected for each meal type.
    /// </summary>
    public class MealDirector
    {
        /// <summary>
        /// Creates a vegetarian meal using the provided builder.
        /// </summary>
        /// <param name="builder">The builder instance used to construct the meal.</param>
        /// <returns>A fully constructed vegetarian meal with a main course, side dish, and drink.</returns>
        public Meals CreateVegMeal(IMealBuilder builder)
        {
            return builder
                .AddMainCourse("Veggie Burger") 
                .AddSideDish("French Fries")    
                .AddDrink("Orange Juice")       
                .Build();                       
        }

        /// <summary>
        /// Creates a non-vegetarian meal using the provided builder.
        /// </summary>
        /// <param name="builder">The builder instance used to construct the meal.</param>
        /// <returns>A fully constructed non-vegetarian meal with a main course, side dish, and drink.</returns>
        public Meals CreateNonVegMeal(IMealBuilder builder)
        {
            return builder
                .AddMainCourse("Chicken Burger") 
                .AddSideDish("Onion Rings")     
                .AddDrink("Cola")               
                .Build();                      
        }
    }
}
