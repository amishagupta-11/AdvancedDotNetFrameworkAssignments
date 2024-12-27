using BuilderDesignPatternSample.Interfaces;
using BuilderDesignPatternSample.Models;

namespace BuilderDesignPatternSample.Builders
{
    public class MealBuilder:IMealBuilder
    {
        private readonly Meals _meal;

        public MealBuilder()
        {
            _meal = new Meals();
        }

        public IMealBuilder AddMainCourse(string mainCourse)
        {
            _meal.MainCourse = mainCourse;
            return (IMealBuilder)this;
        }

        public IMealBuilder AddSideDish(string sideDish)
        {
            _meal.SideDish = sideDish;
            return (IMealBuilder)this;
        }

        public IMealBuilder AddDrink(string drink)
        {
            _meal.Drink = drink;
            return (IMealBuilder)this;
        }

        public Meals Build()
        {
            return _meal;
        }
    }
}
