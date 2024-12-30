using FactoryPatternSample.Factories;
using FactoryPatternSample.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FactoryPatternSample.Controllers
{
    /// <summary>
    /// Controller responsible for handling notification-related actions.
    /// </summary>
    public class NotificationController : Controller
    {
        /// <summary>
        /// Displays the notification view with an empty model.
        /// </summary>
        /// <returns>The view for sending a notification.</returns>
        public IActionResult Index()
        {
            return View(new NotificationViewModel());
        }

        /// <summary>
        /// Handles the sending of a notification based on the provided view model.
        /// </summary>
        /// <param name="model">The notification view model containing the message and recipient details.</param>
        /// <returns>The view with the result of the notification operation.</returns>
        [HttpPost]
        public IActionResult SendNotification(NotificationViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Use the factory to get the appropriate notification service
                    var notification = NotificationFactory.GetNotification(model.Type);

                    // Send the notification and store the result
                    model.Result = notification.Send(model.Message, model.Recipient);
                }
                catch (ArgumentException ex)
                {
                    // Handle invalid notification type
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }

            // Return the view with the notification result or error
            return View("Index", model);
        }
    }
}
