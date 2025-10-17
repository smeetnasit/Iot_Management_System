using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Iot_Management_System.Hepler;
using Iot_Management_System.Models;
using Iot_Management_System.ViewModal;
using System.Diagnostics;

namespace Iot_Management_System.Controllers
{
    public class HomeController : Controller
    {
        private IClientHelper _clientHelper;
        private HomeViewModal _homeViewModal;
        private readonly IDataProtectionProvider dataProtectionProvider;

        public HomeController(IClientHelper clientHelper, IDataProtectionProvider dataProtectionProvider)
        {
            _clientHelper = clientHelper;
            _homeViewModal = new HomeViewModal(_clientHelper, dataProtectionProvider);

            this.dataProtectionProvider = dataProtectionProvider;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> Add_Sensor(SensorModal sensor)
        {
            var res = await _homeViewModal.Add_Sensor(sensor);
            return Json(res);
        }

        //[HttpGet]
        //public async Task<IActionResult> GetCountries()
        //{
        //    try
        //    {
        //        var res = await _homeViewModal.GetCountries();
        //        return Json(res);
        //    }
        //    catch (Exception ex)
        //    {
        //        string errorMessage = ex.Message;
        //        return Json(500, errorMessage);
        //    }
        //}


        //[HttpPost]
        //public async Task<JsonResult> Insert_MasterCountry(int id)
        //{
        //    var res = await _homeViewModal.Insert_MasterCountry(id);
        //    return Json(res);
        //}


        //[HttpGet]
        //public async Task<IActionResult> GetMasterCountries()
        //{
        //    try
        //    {
        //        var res = await _homeViewModal.GetMasterCountries();
        //        return Json(res);
        //    }
        //    catch (Exception ex)
        //    {
        //        string errorMessage = ex.Message;
        //        return Json(500, errorMessage);
        //    }
        //}


        //[HttpGet]
        //public async Task<IActionResult> GetStates(int CountryId)
        //{
        //    try
        //    {
        //        var res = await _homeViewModal.GetStates(CountryId);
        //        return Json(res);
        //    }
        //    catch (Exception ex)
        //    {
        //        string errorMessage = ex.Message;
        //        return Json(500, errorMessage);
        //    }
        //}

        //[HttpGet]
        //public async Task<IActionResult> GetCities(int StateId)
        //{
        //    try
        //    {
        //        var res = await _homeViewModal.GetCities(StateId);
        //        return Json(res);
        //    }
        //    catch (Exception ex)
        //    {
        //        string errorMessage = ex.Message;
        //        return Json(500, errorMessage);
        //    }
        //}


        //[HttpGet]
        //public async Task<IActionResult> GetEmployees()
        //{


        //    var emplist = await _homeViewModal.GetEmployees();


        //    return Json(new { data = emplist });
        //}

        //[HttpPut]
        //public async Task<IActionResult> UpdateEmployee(EmployeeModal emp)
        //{


        //    var res = await _homeViewModal.UpdateEmployee(emp);

        //    return Json(res);
        //}


        //[HttpPost]
        //public async Task<IActionResult> DeleteEmployees(int id)
        //{


        //    var res = await _homeViewModal.DeleteEmployees(id);

        //    return Json(res);
        //}



        //[HttpPost]
        //public IActionResult DownloadExcel(ExcelEmployeeModal excelEmployeeModal)
        //{
        //    var stream = new MemoryStream();

        //    using (var package = new ExcelPackage(stream))
        //    {
        //        var worksheet = package.Workbook.Worksheets.Add("Sheet1");

        //        var properties = typeof(ExcelEmployeeModal).GetProperties();

        //        for (int i = 0; i < properties.Length; i++)
        //        {
        //            worksheet.Cells[1, i + 1].Value = properties[i].Name;
        //        }

        //        package.Save();
        //    }

        //    stream.Position = 0;
        //    var fileName = $"EmployeeData_{DateTime.Now:yyyyMMddHHmmss}.xlsx";
        //    var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

        //    return File(stream, contentType, fileName);
        //}
    }

}

