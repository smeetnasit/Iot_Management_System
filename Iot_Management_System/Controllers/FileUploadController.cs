using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;

namespace Iot_Management_System.Controllers
{
    public class FileUploadController : Controller
    {
        private readonly IDataProtector _protector;
        public FileUploadController(IDataProtectionProvider dataProtectionProvider)
        {
            _protector = dataProtectionProvider.CreateProtector("MyCookieEncryptionPurpose");
        }

        [HttpPost("upload")]
        public async Task<IActionResult> Upload(IFormFile file, string filepath)
        {
            try
            {
                if (file == null || file.Length == 0)
                {
                    return BadRequest("No file uploaded.");
                }

                var filePath = Path.Combine(Directory.GetCurrentDirectory(), filepath);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                return Ok("File uploaded successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
