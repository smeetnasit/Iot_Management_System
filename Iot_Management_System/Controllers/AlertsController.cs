using Microsoft.AspNetCore.Mvc;

namespace Iot_Management_System.Controllers
{
    public class AlertsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}