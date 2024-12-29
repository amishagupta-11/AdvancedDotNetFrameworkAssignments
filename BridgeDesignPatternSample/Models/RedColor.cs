using BridgeDesignPatternSample.Interfaces;

namespace BridgeDesignPatternSample.Models
{
    public class RedColor : IShapeColor
    {
        public string FillColor()
        {
            return "Red";
        }
    }
}
