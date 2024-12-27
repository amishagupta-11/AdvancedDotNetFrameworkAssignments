using BuilderDesignPatternSample.Builders;
using BuilderDesignPatternSample.Directors;
using BuilderDesignPatternSample.Interfaces;
using BuilderDesignPatternSample.Models;

IMealBuilder mealBuilder = new MealBuilder();
MealDirector director = new MealDirector();
string? response;

Console.WriteLine("Building meals using Builder Design Pattern:");
Console.WriteLine("Please select your preferred meal (Veg/Non-Veg):");

// Read user input
response = Console.ReadLine()?.Trim()?.ToLower();

if (response == "veg")
{
    Meals vegMeal = director.CreateVegMeal(mealBuilder);
    Console.WriteLine("You selected Veg Meal: " + vegMeal);
}
else if (response == "non-veg")
{
    Meals nonVegMeal = director.CreateNonVegMeal(mealBuilder);
    Console.WriteLine("You selected Non-Veg Meal:\n " + nonVegMeal);
}
else
{
    Console.WriteLine("Invalid input. Defaulting to a custom meal.");

    // Custom meal example
    Meals customMeal = mealBuilder
        .AddMainCourse("Pasta")
        .AddDrink("Lemonade")
        .Build();
    Console.WriteLine("Custom Meal: " + customMeal);
}
