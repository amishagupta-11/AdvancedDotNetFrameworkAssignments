using BridgeDesignPatternSample.Interfaces;
using BridgeDesignPatternSample.Models;
using Microsoft.AspNetCore.Mvc;

namespace BridgeDesignPatternSample.Controllers
{
    public class ShapesController : Controller
    {
        private readonly List<IShapeColor> _colors;
        private readonly List<Shape> _shapes;

        public ShapesController()
        {
            // Initialize colors
            IShapeColor redColor = new RedColor();
            IShapeColor greenColor = new GreenColor();

            // Initialize shapes with colors injected
            _shapes = new List<Shape>
            {
                new Circle(greenColor),  
                new Rectangle(redColor) 
            };

            // Initialize colors list
            _colors = new List<IShapeColor> { redColor, greenColor };
        }

        // Action method to display the form for shape and color selection
        public IActionResult Index()
        {
            // Assigning shapes and colors to ViewData to be accessed in the view
            ViewData["Shapes"] = _shapes;
            ViewData["Colors"] = _colors;

            return View();
        }

        [HttpPost]
        public IActionResult Index(int shapeIndex, int colorIndex)
        {
            // Check if valid indices are provided
            if (shapeIndex < 0 || shapeIndex >= _shapes.Count || colorIndex < 0 || colorIndex >= _colors.Count)
            {
                return View();
            }

            // Get the selected shape and color based on user input
            Shape selectedShape = _shapes[shapeIndex];
            IShapeColor selectedColor = _colors[colorIndex];

            // Update the color of the selected shape
            selectedShape.UpdateColor(selectedColor);

            // Pass the selected shape and color to the view
            ViewData["SelectedShape"] = selectedShape;
            ViewData["SelectedColor"] = selectedColor.FillColor();

            // Return the view with the selected shape and color details
            return View();
        }
    }
}
