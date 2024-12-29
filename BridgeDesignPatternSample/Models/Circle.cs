using BridgeDesignPatternSample.Interfaces;

namespace BridgeDesignPatternSample.Models
{
    public class Circle : Shape
    {
        public Circle(IShapeColor color) : base(color)
        {
        }

        public override string Draw()
        {
            return $"Drawing a Circle with {_color.FillColor()} color.";
        }
    }
}
