using BuilderDesignPatternSample.Models;

namespace BuilderDesignPatternSample.Interfaces
{
    public interface IMealBuilder
    {
        IMealBuilder AddMainCourse(string mainCourse);
        IMealBuilder AddSideDish(string sideDish);
        IMealBuilder AddDrink(string drink);
        Meals Build();
    }
}
