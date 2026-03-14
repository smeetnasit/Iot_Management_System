using Iot_Management_System_API.DTO;
using Iot_Management_System_API.Interface;
using Iot_Management_System_API.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace Iot_Management_System_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public AuthController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            if (string.IsNullOrEmpty(request.Email) ||
                string.IsNullOrEmpty(request.Password))
                return BadRequest(
                    new { message = "Email and password required" });

            var user = await _userRepository.GetUserByEmail(request.Email);
            if (user is null)
                return Unauthorized(
                    new { message = "Invalid email or password" });

            if (!VerifyPassword(request.Password, user.Password_Hash!))
                return Unauthorized(
                    new { message = "Invalid email or password" });

            return Ok(new
            {
                user.User_Id,
                user.Full_Name,
                user.Email,
                user.Role
            });
        }

        private string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(
                Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }

        private bool VerifyPassword(string password, string hash)
        {
            return HashPassword(password) == hash;
        }
    }
}