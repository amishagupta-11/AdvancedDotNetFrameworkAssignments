using DecoratorDesignPattern.Interfaces;

namespace DecoratorDesignPattern.Models
{
    public class Espresso:ICoffee
    {
        public string GetDescription()
        {
            return "Espresso";
        }

        public double Cost()
        {
            return 3.00;  
        }
    }
}
