using BridgeDesignPatternSample.Interfaces;

namespace BridgeDesignPatternSample.Models
{
    public class GreenColor:IShapeColor
    {
        public string FillColor()
        {
            return "Green";
        }
    }
}
    