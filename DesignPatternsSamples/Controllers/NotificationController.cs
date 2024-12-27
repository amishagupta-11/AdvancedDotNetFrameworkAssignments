using FactoryPatternSample.Factories;
using FactoryPatternSample.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FactoryPatternSample.Controllers
{
    public class NotificationController : Controller
    {
        public IActionResult Index()
        {
            return View(new NotificationViewModel());
        }

        [HttpPost]
        public IActionResult SendNotification(NotificationViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var notification = NotificationFactory.GetNotification(model.Type);
                    model.Result = notification.Send(model.Message,model.Recipient);
                }
                catch (ArgumentException ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }

            return View("Index", model);
        }
    }
}
