using Microsoft.AspNetCore.Mvc;

namespace Iot_Management_System.Controllers
{
    public class AlertsController : Controller
    {
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("UserEmail") == null)
                return RedirectToAction("Login", "Auth");
            var role = HttpContext.Session.GetString("UserRole");
            if (role == "Viewer")
                return RedirectToAction("Index", "Dashboard");
            return View();
        }
    }
}