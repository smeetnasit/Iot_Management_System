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

        // [HttpPost]
        //[Route("MasterCountry_Insert")]
        //public async Task<IActionResult> MasterCountryInsert(int id)
        //{
        //    try
        //    {
        //        var res = await _employee.MasterCountryInsert(id);

        //        return Ok(res);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500);
        //    }
        //}


        //[HttpGet]
        //[Route("Get_Countries")]

        //public async Task<IActionResult> GetCountries()
        //{
        //    try
        //    {
        //        var res = await _employee.GetCountries();

        //        return Ok(res);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"An error occurred: {ex.Message}");
        //        return StatusCode(500);
        //    }
        //}



        //[HttpGet]
        //[Route("Get_MasterCountries")]

        //public async Task<IActionResult> GetMasterCountries()
        //{
        //    try
        //    {
        //        var res = await _employee.GetMasterCountries();

        //        return Ok(res);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"An error occurred: {ex.Message}");
        //        return StatusCode(500);
        //    }
        //}

        //[HttpGet]
        //[Route("Get_States")]

        //public async Task<IActionResult> GetStates(int CountryId)
        //{
        //    try
        //    {
        //        var res = await _employee.GetStates(CountryId);

        //        return Ok(res);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"An error occurred: {ex.Message}");
        //        return StatusCode(500);
        //    }
        //}

        //[HttpGet]
        //[Route("Get_Cities")]

        //public async Task<IActionResult> GetCities(int StateId)
        //{
        //    try
        //    {
        //        var res = await _employee.GetCities(StateId);

        //        return Ok(res);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"An error occurred: {ex.Message}");
        //        return StatusCode(500);
        //    }
        //}

        //[HttpGet]
        //[Route("GetEmployees")]

        //public async Task<IActionResult> GetEmployees()
        // {
        //    try
        //    {
        //        var res = await _employee.GetEmployees();

        //        return Ok(res);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500);
        //    }
        //}

        //[HttpPut]
        //[Route("UpdateEmployees")]

        //public async Task<IActionResult> Emp_Update(Sensor emp)
        //{
        //    try
        //    {
        //        var res = await _employee.Emp_Update(emp);

        //        return Ok(res);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500);
        //    }
        //}

        //[HttpPost]
        //[Route("DeleteEmployees")]

        //public async Task<IActionResult> DeleteEmployees(int id)
        //{
        //    try
        //    {
        //        var res = await _employee.DeleteEmployees(id);

        //        return Ok(res);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500);
        //    }
        //}


        //[HttpPost("ImportEmployees")]
        //public async Task<IActionResult> ImportEmployees(IFormFile file)
        //{
        //    try
        //    {
        //        if (file == null || file.Length == 0)
        //        {
        //            return BadRequest("File not selected.");
        //        }

        //        if (!Path.GetExtension(file.FileName).Equals(".xlsx", StringComparison.OrdinalIgnoreCase))
        //        {
        //            return BadRequest("Invalid file format. Please select a .xlsx file.");
        //        }

        //        // Read Excel data and process
        //        using (var stream = new MemoryStream())
        //        {
        //            await file.CopyToAsync(stream);
        //            using (var package = new ExcelPackage(stream))
        //            {
        //                var worksheet = package.Workbook.Worksheets[0]; // Assuming first worksheet

        //                var employees = new List<GetExcelEmployee>();

        //                for (int row = worksheet.Dimension.Start.Row + 1; row <= worksheet.Dimension.End.Row; row++)
        //                {
        //                    var emp = new GetExcelEmployee
        //                    {
                               
        //                        EmpName = worksheet.Cells[row, 1].Value?.ToString().Trim(),
        //                        Address1 = worksheet.Cells[row, 2].Value?.ToString().Trim(),
        //                        Address2 = worksheet.Cells[row, 3].Value?.ToString().Trim(),
        //                        Country = long.TryParse(worksheet.Cells[row, 4].Value?.ToString().Trim(), out long country) ? country : 0,
        //                        State = long.TryParse(worksheet.Cells[row, 5].Value?.ToString().Trim(), out long state) ? state : 0,
        //                        City = long.TryParse(worksheet.Cells[row, 6].Value?.ToString().Trim(), out long city) ? city : 0,
        //                        MobileNo = long.TryParse(worksheet.Cells[row, 7].Value?.ToString().Trim(), out long mobileNo) ? mobileNo : 0,
        //                        PhoneNo = long.TryParse(worksheet.Cells[row, 8].Value?.ToString().Trim(), out long phoneNo) ? phoneNo : 0,
        //                        Email = worksheet.Cells[row, 9].Value?.ToString().Trim(),
        //                        EmpDesignation = worksheet.Cells[row, 10].Value?.ToString().Trim(),
        //                        EmpSalary = long.TryParse(worksheet.Cells[row, 11].Value?.ToString().Trim(), out long empSalary) ? empSalary : 0,
        //                        Password = worksheet.Cells[row, 12].Value?.ToString().Trim(),
        //                        Id = long.TryParse(worksheet.Cells[row, 13].Value?.ToString().Trim(), out long id) ? id : 0,
        //                    };

        //                    employees.Add(emp);

        //                }

        //                foreach (var emp in employees)
        //                {
        //                    await _employee.InsertExcelEmployee(emp); 
        //                }

        //                return Ok("Employees imported successfully.");
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, $"Internal server error: {ex.Message}");
        //    }
        //}
    }
}
