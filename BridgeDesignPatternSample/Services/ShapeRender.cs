using BridgeDesignPatternSample.Models;

namespace BridgeDesignPatternSample.Services
{
    /// <summary>
    /// Responsible for rendering shapes. It delegates the task of drawing the shape to the shape's own `Draw` method.
    /// </summary>
    public class ShapeRenderer
    {
        private Shape Shape;

        /// <summary>
        /// Initializes a new instance of the ShapeRenderer class with a specific shape.
        /// </summary>
        /// <param name="shape">The shape to be rendered.</param>
        public ShapeRenderer(Shape shape)
        {
            Shape = shape;
        }

        /// <summary>
        /// Renders the current shape by calling its `Draw` method.
        /// </summary>
        public void RenderShape()
        {
            Shape.Draw();
        }

        /// <summary>
        /// Renders a specific shape (e.g., Rectangle) by calling its `Draw` method.
        /// </summary>
        /// <param name="shape">The shape to be rendered.</param>
        public void RenderShapeForRectangle(Shape shape)
        {
            shape.Draw();
        }
    }
}
