using BridgeDesignPatternSample.Interfaces;
using BridgeDesignPatternSample.Models;
using Microsoft.AspNetCore.Mvc;

namespace BridgeDesignPatternSample.Controllers
{
    /// <summary>
    /// The ShapesController handles the logic for displaying shapes and colors,
    /// allowing users to select a shape and color, and updates the shape's color accordingly.
    /// </summary>
    public class ShapesController : Controller
    {
        private readonly List<IShapeColor> Colors;  
        private readonly List<Shape> Shapes;      

        /// <summary>
        /// Initializes the controller by creating shapes and colors with their dependencies.
        /// </summary>
        public ShapesController()
        {
            // Initialize colors
            IShapeColor redColor = new RedColor();
            IShapeColor greenColor = new GreenColor();

            // Initialize shapes with colors injected.
            Shapes = new List<Shape>
            {
                new Circle(greenColor),  
                new Rectangle(redColor)  
            };

            // Initialize colors list
            Colors = new List<IShapeColor> { redColor, greenColor };
        }

        /// <summary>
        /// Displays the initial form with a list of available shapes and colors for selection.
        /// </summary>
        /// <returns>A view that allows users to choose a shape and color.</returns>
        public IActionResult Index()
        {
            // Assigning shapes and colors to ViewData to be accessed in the view
            ViewData["Shapes"] = Shapes;
            ViewData["Colors"] = Colors;

            return View();
        }

        /// <summary>
        /// Handles the form submission for shape and color selection,
        /// updates the selected shape's color, and returns the updated details.
        /// </summary>
        /// <param name="shapeIndex">Index of the selected shape.</param>
        /// <param name="colorIndex">Index of the selected color.</param>
        /// <returns>A view displaying the selected shape and color.</returns>
        [HttpPost]
        public IActionResult Index(int shapeIndex, int colorIndex)
        {
            // Check if valid indices are provided.
            if (shapeIndex < 0 || shapeIndex >= Shapes.Count || colorIndex < 0 || colorIndex >= Colors.Count)
            {
                return View();
            }

            // Get the selected shape and color based on user input.
            Shape selectedShape = Shapes[shapeIndex];
            IShapeColor selectedColor = Colors[colorIndex];

            // Update the color of the selected .
            selectedShape.UpdateColor(selectedColor);

            // Pass the selected shape and color to the view.
            ViewData["SelectedShape"] = selectedShape;
            ViewData["SelectedColor"] = selectedColor.FillColor();

            // Return the view with the selected shape and color details.
            return View();
        }
    }
}
