using DecoratorDesignPattern.Decorators;
using DecoratorDesignPattern.Interfaces;
using DecoratorDesignPattern.Models;
using Microsoft.AspNetCore.Mvc;

namespace DecoratorDesignPattern.Controllers
{
    /// <summary>
    /// Controller for handling coffee and decorator selections.
    /// Allows users to choose a coffee type and apply decorators, displaying the resulting description and cost.
    /// </summary>
    public class CoffeeController : Controller
    {
        /// <summary>
        /// Loads the initial page with available coffee types and decorators.
        /// Populates dropdown lists with the coffee types (Espresso, Coffee, Cappuccino) and decorator options (Milk, Sugar, None).
        /// </summary>
        /// <returns>Returns the view with the coffee types and decorators</returns>
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

        /// <summary>
        /// Handles form submission for selecting a coffee type and decorators.
        /// Based on user selection, applies the chosen decorators to the selected coffee and returns the updated description and cost.
        /// </summary>
        /// <param name="coffeeType">The selected coffee type</param>
        /// <param name="selectedDecorators">The list of selected decorators to apply to the coffee</param>
        /// <returns>Returns the view with updated coffee description and cost</returns>
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
