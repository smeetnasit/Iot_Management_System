using Iot_Management_System.Hepler;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace Iot_Management_System.Controllers
{
    public class AuthController : Controller
    {
        private readonly IClientHelper _clientHelper;

        public AuthController(IClientHelper clientHelper)
        {
            _clientHelper = clientHelper;
        }

        // GET: /Account/Login
        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("UserEmail") != null)
                return RedirectToAction("Index", "Home");
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            var client = await _clientHelper.PrepareAuthenticatedClient();

            var payload = JsonSerializer.Serialize(new { email, password });
            var content = new StringContent(payload,
                Encoding.UTF8, "application/json");

            var response = await client.PostAsync(
                "https://localhost:7061/api/Auth/login", content);

            if (!response.IsSuccessStatusCode)
            {
                ViewBag.Error = "Invalid email or password";
                return View();
            }

            var json = await response.Content.ReadAsStringAsync();
            var user = JsonSerializer.Deserialize<dynamic>(json,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

            var userDict = JsonSerializer.Deserialize<Dictionary<string, object>>(json);

            HttpContext.Session.SetString("UserEmail",
                userDict!["email"].ToString() ?? "");
            HttpContext.Session.SetString("UserName",
                userDict!["full_Name"].ToString() ?? "");
            HttpContext.Session.SetString("UserRole",
                userDict!["role"].ToString() ?? "");

            return RedirectToAction("Index", "Home");
        }

        // GET: /Account/Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}