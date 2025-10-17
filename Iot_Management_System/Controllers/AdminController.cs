//using Microsoft.AspNetCore.DataProtection;
//using Microsoft.AspNetCore.Mvc;
//using Iot_Management_System.Hepler;
//using Iot_Management_System.ViewModal;

//namespace Iot_Management_System.Controllers
//{
//    public class AdminController : Controller
//    {

//        private IClientHelper _clientHelper;
//        private HomeViewModal _homeViewModal;
//        private readonly IDataProtectionProvider dataProtectionProvider;

//        public AdminController(IClientHelper clientHelper, IDataProtectionProvider dataProtectionProvider)
//        {
//            _clientHelper = clientHelper;
//            _homeViewModal = new HomeViewModal(_clientHelper, dataProtectionProvider);

//            this.dataProtectionProvider = dataProtectionProvider;
//        }
//        public IActionResult Index()
//        {
//            return View();
//        }

//        [HttpGet]
//        public async Task<JsonResult> AdminLogin(string Email, string Password, int usertype)
//        {
//            try
//            {
//                var res = await _homeViewModal.AdminLogin(Email, Password, usertype);
//                return Json(res);
//            }
//            catch (Exception ex)
//            {
//                string errorMessage = ex.Message;
//                return Json(500, errorMessage);
//            }
//        }

//    }
//}
