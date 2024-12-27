using BuilderDesignPatternSample.Interfaces;
using BuilderDesignPatternSample.Models;

namespace BuilderDesignPatternSample.Directors
{
    public class MealDirector
    {
        public Meals CreateVegMeal(IMealBuilder builder)
        {
            return builder
                .AddMainCourse("Veggie Burger")
                .AddSideDish("French Fries")
                .AddDrink("Orange Juice")
                .Build();
        }

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
