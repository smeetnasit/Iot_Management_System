using Iot_Management_System_API.DTO;
using Iot_Management_System_API.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Iot_Management_System_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ISensor _sensor;
        private readonly IConfiguration _configuration;

        public HomeController(ISensor sensor, IConfiguration configuration)
        {
            _sensor = sensor;
            _configuration = configuration;
        }


        [HttpPost]
        [Route("Add_Sensor")]
        public async Task<IActionResult> Add_Sensor(Sensor sensor)
        {
            try
            {
                var res = await _sensor.Add_Sensor(sensor);

                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }



        [HttpGet]
        [Route("Get_Sensor_Units")]

        public async Task<IActionResult> Get_Sensor_Units()
        {
            try
            {
                var res = await _sensor.Get_Sensor_Units();

                return Ok(res);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return StatusCode(500);
            }
        }


        [HttpGet]
        [Route("GetSensorsData")]

        public async Task<IActionResult> GetSensorsData()
        {
            try
            {
                var res = await _sensor.GetSensorsData();

                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        [Route("DeleteSensorsData")]

        public async Task<IActionResult> DeleteSensorsData(int id)
        {
            try
            {
                var res = await _sensor.DeleteSensorsData(id);

                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }


     
    }
}
