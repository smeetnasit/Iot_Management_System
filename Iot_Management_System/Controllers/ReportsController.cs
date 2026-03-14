using Microsoft.AspNetCore.Mvc;

namespace Iot_Management_System.Controllers
{
    public class ReportsController : Controller
    {
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("UserEmail") == null)
                return RedirectToAction("Login", "Auth");
            return View();
        }
    }
}