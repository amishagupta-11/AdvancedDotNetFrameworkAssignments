using BridgeDesignPatternSample.Interfaces;

namespace BridgeDesignPatternSample.Models
{
    /// <summary>
    /// Abstract class representing a shape. The shape can have different colors, which are applied via the IShapeColor interface.
    /// </summary>
    public abstract class Shape
    {
        // The color associated with the shape, using the IShapeColor interface.
        protected IShapeColor _color;

        /// <summary>
        /// Initializes a new instance of the Shape class with a specified color.
        /// </summary>
        /// <param name="color">The color to assign to the shape, implemented via the IShapeColor interface.</param>
        protected Shape(IShapeColor color)
        {
            _color = color;
        }

        /// <summary>
        /// Abstract method for drawing the shape. This method must be implemented in derived classes.
        /// </summary>
        /// <returns>A string describing the drawn shape and its color.</returns>
        public abstract string Draw();

        /// <summary>
        /// Updates the color of the shape to a new color.
        /// </summary>
        /// <param name="newColor">The new color to assign to the shape, implemented via the IShapeColor interface.</param>
        public void UpdateColor(IShapeColor newColor)
        {
            _color = newColor;
        }
    }
}
