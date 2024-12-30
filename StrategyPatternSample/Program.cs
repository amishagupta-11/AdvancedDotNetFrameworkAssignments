using StrategyPatternSample.Context;
using StrategyPatternSample.Strategies;

var shippingContext = new ShippingContext();

Console.WriteLine("Enter the order total:");
var orderTotal = decimal.Parse(Console.ReadLine());

Console.WriteLine("Choose a shipping option:");
Console.WriteLine("1. Standard Shipping");
Console.WriteLine("2. Express Shipping");
Console.WriteLine("3. Free Shipping");

var choice = Console.ReadLine();

switch (choice)
{
    case "1":
        shippingContext.SetShippingStrategy(new StandardShippingStrategy());
        break;

    case "2":
        shippingContext.SetShippingStrategy(new ExpressShippingStrategy());
        break;

    case "3":
        shippingContext.SetShippingStrategy(new FreeShippingStrategy());
        break;

    default:
        Console.WriteLine("Invalid choice.");
        return;
}

var shippingCost = shippingContext.GetShippingCost(orderTotal);
Console.WriteLine($"The shipping cost is: {shippingCost:C}");
        