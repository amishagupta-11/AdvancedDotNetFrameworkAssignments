using DecoratorDesignPattern.Interfaces;

namespace DecoratorDesignPattern.Decorators
{
    public class MilkDecorator : ICoffee
    {
        private readonly ICoffee _coffee;
        public MilkDecorator(ICoffee coffee)
        {
            _coffee = coffee;
        }

        public string GetDescription()
        {
            return _coffee.GetDescription() + ", Milk";
        }

        public double Cost()
        {
            return _coffee.Cost() + 1.50;  
        }
    }
}
