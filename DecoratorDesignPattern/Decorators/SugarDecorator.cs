using DecoratorDesignPattern.Interfaces;

namespace DecoratorDesignPattern.Decorators
{
    public class SugarDecorator : ICoffee
    {
        private readonly ICoffee _coffee;

        public SugarDecorator(ICoffee coffee)
        {
            _coffee = coffee;
        }

        public string GetDescription()
        {
            return _coffee.GetDescription() + ", Sugar";
        }

        public double Cost()
        {
            return _coffee.Cost() + 0.75; 
        }
    }
}
