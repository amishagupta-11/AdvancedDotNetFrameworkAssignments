using BridgeDesignPatternSample.Interfaces;

namespace BridgeDesignPatternSample.Models
{
    /// <summary>
    /// Concrete implementation of the Shape class representing a Circle.
    /// </summary>
    public class Circle : Shape
    {
        /// <summary>
        /// Initializes a new instance of the Circle class with a specified color.
        /// </summary>
        /// <param name="color">The color used to fill the Circle.</param>
        public Circle(IShapeColor color) : base(color)
        {
        }

        /// <summary>
        /// Draws the Circle and returns a description of the shape along with its color.
        /// </summary>
        /// <returns>A string describing the drawing of the Circle with its color.</returns>
        public override string Draw()
        {
            return $"Drawing a Circle with {_color.FillColor()} color.";
        }
    }
}
