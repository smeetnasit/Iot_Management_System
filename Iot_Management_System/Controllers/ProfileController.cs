//using Microsoft.AspNetCore.DataProtection;
//using Microsoft.AspNetCore.Mvc;
//using Iot_Management_System.Hepler;
//using Iot_Management_System.Models;
//using Iot_Management_System.ViewModal;

//namespace Iot_Management_System.Controllers
//{
//    public class ProfileController : Controller
//    {

//        private IClientHelper _clientHelper;
//        private ProfileViewModal _profileViewModal;
//        private readonly IDataProtectionProvider dataProtectionProvider;

//        public ProfileController(IClientHelper clientHelper, IDataProtectionProvider dataProtectionProvider)
//        {
//            _clientHelper = clientHelper;
//            _profileViewModal = new ProfileViewModal(_clientHelper, dataProtectionProvider);

//            this.dataProtectionProvider = dataProtectionProvider;
//        }
//        public IActionResult Profile()
//        {
//            return View();
//        }





//        [HttpGet] 
//        public async Task<IActionResult> GetEmpProfile(string email)
//        {
//            try
//            {
//                var res = await _profileViewModal.GetEmpProfile(email);
//                return Json(res);
//            }
//            catch (Exception ex)
//            {
//                string errorMessage = ex.Message;
//                return Json(500, errorMessage);
//            }
//        }


//        [HttpPut]
//        public async Task<JsonResult> UpsertProfile(Profile profile)
//        {
//            var controllerName = this.ControllerContext.ActionDescriptor.ControllerName;
//            var res1 = await _profileViewModal.UploadFileAsync(profile.ProfileLink, controllerName);
//            profile.ProfileLink_String = res1;
//            var res = await _profileViewModal.UpsertProfile(profile);
//            return Json(res);
//        }



//        //[HttpPost]
//        //public async Task<JsonResult> AddEmpPost(AddPost add)
//        // {
//        //    var controllerName = this.ControllerContext.ActionDescriptor.ControllerName;
//        //    var res1 = await _profileViewModal.UploadFileAsync(add.PostLink, controllerName);
//        //    add.Post_Link_String = res1;
//        //    var res = await _profileViewModal.AddPost(add);
//        //    return Json(res);
//        //}

//        [HttpPost]
//        public async Task<JsonResult> AddEmpPost(AddPostModal add)
//        {
//            var controllerName = this.ControllerContext.ActionDescriptor.ControllerName;
//            var res1 = await _profileViewModal.UploadFileAsync(add.PostLink, controllerName);
//            add.Post_Link_String = res1;
//            var res = await _profileViewModal.AddPost(add);
//            return Json(res);
//        }



//        [HttpGet]
//        public async Task<JsonResult> Get_Post(int empId)
//        {
//            var res = await _profileViewModal.Get_Post(empId);
//            return Json(res);
//        }


//    }
//}
