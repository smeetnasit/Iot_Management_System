using Iot_Management_System_API.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Iot_Management_System_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly ISensor _sensorRepository;

        public DashboardController(ISensor sensorRepository)
        {
            _sensorRepository = sensorRepository;
        }

        // GET: api/dashboard/latest
        [HttpGet("latest")]
        public async Task<IActionResult> GetLatestReadings()
        {
            var readings = await _sensorRepository.GetLatestReadings();
            return Ok(readings);
        }

        // POST: api/dashboard/pause
        [HttpPost("pause")]
        public IActionResult PauseSimulation()
        {
            SimulationControl.IsRunning = false;
            return Ok(new { message = "Simulation paused", isRunning = false });
        }

        // POST: api/dashboard/resume
        [HttpPost("resume")]
        public IActionResult ResumeSimulation()
        {
            SimulationControl.IsRunning = true;
            return Ok(new { message = "Simulation resumed", isRunning = true });
        }

        // GET: api/dashboard/status
        [HttpGet("status")]
        public IActionResult GetStatus()
        {
            return Ok(new { isRunning = SimulationControl.IsRunning });
        }

        // GET: api/dashboard/alerts
        [HttpGet("alerts")]
        public async Task<IActionResult> GetAlertReadings()
        {
            var readings = await _sensorRepository.GetAlertReadings();
            return Ok(readings);
        }

        // PUT: api/dashboard/alert/{id}/status
        [HttpPut("alert/{id}/status")]
        public async Task<IActionResult> UpdateAlertStatus(int id, [FromBody] AlertStatusRequest request)
        {
            if (string.IsNullOrEmpty(request.Status))
                return BadRequest(new { message = "Status is required" });

            var validStatuses = new[] { "New", "Acknowledged", "Resolved" };
            if (!validStatuses.Contains(request.Status))
                return BadRequest(new { message = "Invalid status" });

            var result = await _sensorRepository
                .UpdateAlertStatus(id, request.Status);

            if (!result)
                return NotFound(new { message = "Alert not found" });

            return Ok(new
            {
                message = $"Alert {request.Status} successfully",
                readingId = id,
                status = request.Status
            });
        }

    }
}