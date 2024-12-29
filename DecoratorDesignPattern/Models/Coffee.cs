using DecoratorDesignPattern.Interfaces;

namespace DecoratorDesignPattern.Models
{
    public class Coffee:ICoffee
    {
        public string GetDescription()
        {
            return "Basic Coffee";
        }

        public double Cost()
        {
            return 5.00;  
        }
    }
}
