namespace BridgeDesignPatternSample.Interfaces
{
    /// <summary>
    /// Interface that defines the contract for shape color implementations.
    /// Classes implementing this interface should provide a method to fill a shape with a color.
    /// </summary>
    public interface IShapeColor
    {
        /// <summary>
        /// Fills a shape with a specific color.
        /// </summary>
        /// <returns>A string representing the color applied to the shape.</returns>
        string FillColor();
    }
}
