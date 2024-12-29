using BridgeDesignPatternSample.Interfaces;

namespace BridgeDesignPatternSample.Models
{
    public class Rectangle : Shape
    {
        public Rectangle(IShapeColor color) : base(color)
        {
        }

        public override string Draw()
        {
            return $"Drawing a Rectangle with {_color.FillColor()} color.";
        }
    }
}
