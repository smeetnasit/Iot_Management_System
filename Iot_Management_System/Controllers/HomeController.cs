using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Iot_Management_System.Hepler;
using Iot_Management_System.Models;
using Iot_Management_System.ViewModal;
using System.Diagnostics;

namespace Iot_Management_System.Controllers
{
    public class HomeController : Controller
    {
        private IClientHelper _clientHelper;
        private HomeViewModal _homeViewModal;
        private readonly IDataProtectionProvider dataProtectionProvider;

        public HomeController(IClientHelper clientHelper, IDataProtectionProvider dataProtectionProvider)
        {
            _clientHelper = clientHelper;
            _homeViewModal = new HomeViewModal(_clientHelper, dataProtectionProvider);

            this.dataProtectionProvider = dataProtectionProvider;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("UserEmail") == null)
                return RedirectToAction("Login", "Auth");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add_Sensor(SensorModal sensor)
        {
            if (HttpContext.Session.GetString("UserRole") == "Viewer")
                return Json(new { success = false, message = "Access denied" });
            var res = await _homeViewModal.Add_Sensor(sensor);
            return Json(res);
        }

        [HttpGet]
        public async Task<IActionResult> Get_Sensor_Units()
        {
            try
            {
                var res = await _homeViewModal.Get_Sensor_Units();
                return Json(res);
            }
            catch (Exception ex)
            {
                string errorMessage = ex.Message;
                return Json(500, errorMessage);
            }
        }


        [HttpGet]
        public async Task<IActionResult> GetSensorsData()
        {


            var sensorsdata = await _homeViewModal.GetSensorsData();


            return Json(new { data = sensorsdata });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteSensorsData(int id)
        {
            var role = HttpContext.Session.GetString("UserRole");
            if (role == "Viewer" || role == "Engineer")
                return Json(new { success = false, message = "Access denied" });
            var res = await _homeViewModal.DeleteSensorsData(id);
            return Json(res);
        }



    }

}

