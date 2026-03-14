using Iot_Management_System_API.DTO;
using Iot_Management_System_API.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace Iot_Management_System_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // GET: api/users
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userRepository.GetAllUsers();
            return Ok(users);
        }

        // POST: api/users
        [HttpPost]
        public async Task<IActionResult> UpsertUser(
            [FromBody] UpsertUserRequest request)
        {
            if (string.IsNullOrEmpty(request.Email))
                return BadRequest(new { message = "Email is required" });

            string passwordHash = "";
            if (request.User_Id == 0)
            {
                if (string.IsNullOrEmpty(request.Password))
                    return BadRequest(
                        new { message = "Password required for new user" });

                using var sha256 = SHA256.Create();
                var bytes = sha256.ComputeHash(
                    Encoding.UTF8.GetBytes(request.Password));
                passwordHash = Convert.ToBase64String(bytes);
            }

            await _userRepository.UpsertUser(
                request.Full_Name,
                request.Email,
                passwordHash,
                request.Role,
                request.User_Id,   
                request.IsActive   
            );

            return Ok(new
            {
                message = request.User_Id == 0
                ? "User created" : "User updated"
            });
        }

        // DELETE: api/users/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userRepository.DeleteUser(id);
            return Ok(new { message = "User deactivated" });
        }
    }
}