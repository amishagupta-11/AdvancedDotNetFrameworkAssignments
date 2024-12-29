using BridgeDesignPatternSample.Interfaces;

namespace BridgeDesignPatternSample.Models
{
    public abstract class Shape
    {
        protected IShapeColor _color;

        // Constructor to initialize the color
        protected Shape(IShapeColor color)
        {
            _color = color;
        }

        // Abstract method to draw the shape
        public abstract string Draw();
        public void UpdateColor(IShapeColor newColor)
        {
            _color = newColor;
        }
    }
}
