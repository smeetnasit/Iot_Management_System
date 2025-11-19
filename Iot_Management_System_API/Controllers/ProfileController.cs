//using Emp_API.DTO;
//using Emp_API.Interface;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace Emp_API.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ProfileController : ControllerBase
//    {

//        private readonly IProfile _profile;
//        private readonly IConfiguration _configuration;

//        public ProfileController(IProfile profile, IConfiguration configuration)
//        {
//            _profile = profile;
//            _configuration = configuration;
//        }




//        [HttpPost]
//        [Route("Profile_Insert")]
//        public async Task<IActionResult> ProfileInsert(Profile profile)
//        {
//            try
//            {
//                var res = await _profile.ProfileInsert(profile);

//                return Ok(res);
//            }
//            catch (Exception ex)
//            {
//                return StatusCode(500);
//            }
//        }


//        [HttpGet]
//        [Route("Get_Emp_Profile")]
//        public async Task<IActionResult> GetEmpProfile(string email)
//        {
//            try
//            {
//                var res = await _profile.GetEmpProfile(email);

//                return Ok(res);
//            }
//            catch (Exception ex)
//            {
//                return StatusCode(500);
//            }
//        }


//        [HttpPut]
//        [Route("Upsert_Profile")]
//        public async Task<IActionResult> Profile_Update([FromBody] UpsertEmpProfile profile)
//        {
//            try
//            {
//                var res = await _profile.UpsertProfile(profile);

//                return Ok(res);
//            }
//            catch (Exception ex)
//            {
//                return StatusCode(500);
//            }
//        }



//        [HttpPost]
//        [Route("Post_Insert")]
//        public async Task<IActionResult> Post_Insert([FromBody]AddPost add)
//        {
//            try
//            {
//                var res = await _profile.Post_Insert(add);

//                return Ok(res);
//            }
//            catch (Exception ex)
//            {
//                return StatusCode(500);
//            }
//        }


//        [HttpGet]
//        [Route("Get_Post")]
//        public async Task<IActionResult> Get_Post(int empId)
//        {
//            try
//            {
//                var user = await _profile.Get_Post(empId);
//                if (user == null)
//                {
//                    return NotFound();
//                }
//                return Ok(user);
//            }
//            catch (Exception ex)
//            {
//                return StatusCode(500, $"An error occurred: {ex.Message}");
//            }
//        }
//    }
//}
