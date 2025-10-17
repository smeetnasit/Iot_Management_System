//using Emp_API.Interface;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace Emp_API.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class AdminController : ControllerBase
//    {
//        private readonly ISensor _employee;
//        private readonly IConfiguration _configuration;

//        public AdminController(ISensor employee, IConfiguration configuration)
//        {
//            _employee = employee;
//            _configuration = configuration;
//        }


//        [HttpGet]
//        [Route("AdminLogin")]
//        public async Task<IActionResult> AdminLogin(string email, string password, int usertype)
//        {
//            try
//            {
//                if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
//                {
//                    return BadRequest("Email and password are required.");
//                }

//                var admin = await _employee.AdminLogin(email, password, usertype);

//                return Ok(admin);

//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine(ex);
//                return StatusCode(500, "An error occurred while processing your request.");
//            }
//        }


//    }
//}
