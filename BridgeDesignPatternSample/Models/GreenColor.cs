using BridgeDesignPatternSample.Interfaces;

namespace BridgeDesignPatternSample.Models
{
    /// <summary>
    /// Concrete implementation of the IShapeColor interface representing the Green color.
    /// </summary>
    public class GreenColor : IShapeColor
    {
        /// <summary>
        /// Returns the color name 'Green' when called.
        /// </summary>
        /// <returns>A string representing the color 'Green'.</returns>
        public string FillColor()
        {
            return "Green";
        }
    }
}
