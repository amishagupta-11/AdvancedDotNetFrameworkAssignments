using BridgeDesignPatternSample.Interfaces;

namespace BridgeDesignPatternSample.Models
{
    /// <summary>
    /// Concrete implementation of the Shape class representing a Rectangle.
    /// </summary>
    public class Rectangle : Shape
    {
        /// <summary>
        /// Initializes a new instance of the Rectangle class with the specified color.
        /// </summary>
        /// <param name="color">The color of the rectangle, injected via dependency injection.</param>
        public Rectangle(IShapeColor color) : base(color)
        {
        }

        /// <summary>
        /// Draws the rectangle and returns a string representation of the shape along with its color.
        /// </summary>
        /// <returns>A string describing the drawn rectangle with its color.</returns>
        public override string Draw()
        {
            return $"Drawing a Rectangle with {_color.FillColor()} color.";
        }
    }
}
