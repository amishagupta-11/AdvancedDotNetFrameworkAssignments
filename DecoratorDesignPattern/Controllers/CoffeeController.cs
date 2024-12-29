using DecoratorDesignPattern.Decorators;
using DecoratorDesignPattern.Interfaces;
using DecoratorDesignPattern.Models;
using Microsoft.AspNetCore.Mvc;

namespace DecoratorDesignPattern.Controllers
{
    public class CoffeeController : Controller
    {
        // The GET method to load the initial page with the available coffee and decorators
        public IActionResult Index()
        {
            // Create lists of available coffee types and decorators for the dropdown
            List<string> coffeeTypes = new List<string> { "Espresso", "Coffee", "Cappuccino" };
            List<string> decorators = new List<string> { "Milk", "Sugar", "None" };

            // Prepare view data to pass to the view for dropdown selections
            ViewData["CoffeeTypes"] = coffeeTypes;
            ViewData["Decorators"] = decorators;

            return View();
        }

        // The POST method to handle form submission and apply decorators
        [HttpPost]
        public IActionResult Index(string coffeeType, List<string> selectedDecorators)
        {
            // Initialize the base coffee based on the user's selection
            ICoffee coffee = coffeeType switch
            {
                "Espresso" => new Espresso(),
                "Coffee" => new Coffee(),
                _ => new Espresso(),
            };

            // Apply selected decorators
            foreach (var decorator in selectedDecorators)
            {
                if (decorator == "Milk")
                    coffee = new MilkDecorator(coffee);
                else if (decorator == "Sugar")
                    coffee = new SugarDecorator(coffee);
            }

            // Passing the description and cost to the view
            ViewData["Description"] = coffee.GetDescription();
            ViewData["Cost"] = coffee.Cost();

            // Reload dropdown lists
            ViewData["CoffeeTypes"] = new List<string> { "Espresso", "Coffee", "Cappuccino" };
            ViewData["Decorators"] = new List<string> { "Milk", "Sugar", "None" };

            return View();
        }
    }
}
