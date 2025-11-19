using Microsoft.AspNetCore.Mvc;

namespace Iot_Management_System.Controllers
{
    public class Dashboard : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
