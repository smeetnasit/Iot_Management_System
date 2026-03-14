using Iot_Management_System.Hepler;
using Iot_Management_System.Models;
using Iot_Management_System.ViewModal;
using Microsoft.AspNetCore.Mvc;

namespace Iot_Management_System.Controllers
{
    public class UsersController : Controller
    {
        private readonly IClientHelper _clientHelper;
        private readonly UsersViewModal _usersViewModal;

        public UsersController(IClientHelper clientHelper)
        {
            _clientHelper = clientHelper;
            _usersViewModal = new UsersViewModal(_clientHelper);
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("UserEmail") == null)
                return RedirectToAction("Login", "Auth");
            if (HttpContext.Session.GetString("UserRole") != "Admin")
                return RedirectToAction("Index", "Home");
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _usersViewModal.GetAllUsers();
            return Json(new { data = users });
        }

        [HttpPost]
        public async Task<IActionResult> UpsertUser(UserModel user)
        {
            var res = await _usersViewModal.UpsertUser(user);
            return Json(res);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var res = await _usersViewModal.DeleteUser(id);
            return Json(res);
        }
    }
}