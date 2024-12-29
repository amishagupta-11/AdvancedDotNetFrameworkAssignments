using BridgeDesignPatternSample.Models;

namespace BridgeDesignPatternSample.Services
{
    public class ShapeRenderer
    {
        private Shape _shape;

        // Constructor accepts a shape that already has a color
        public ShapeRenderer(Shape shape)
        {
            _shape = shape;
        }

        // Render the shape with color
        public void RenderShape()
        {
            _shape.Draw();
        }
        public void RenderShapeForRectangle(Shape shape)
        {
            shape.Draw();  
        }
    }
}
