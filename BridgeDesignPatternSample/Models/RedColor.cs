using BridgeDesignPatternSample.Interfaces;

namespace BridgeDesignPatternSample.Models
{
    /// <summary>
    /// Concrete implementation of IShapeColor interface representing the color Red.
    /// </summary>
    public class RedColor : IShapeColor
    {
        /// <summary>
        /// Returns the color "Red" for the shape.
        /// </summary>
        /// <returns>A string representing the color Red.</returns>
        public string FillColor()
        {
            return "Red";
        }
    }
}
