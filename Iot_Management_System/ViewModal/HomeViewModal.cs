using Microsoft.AspNetCore.DataProtection;
using Iot_Management_System.Hepler;
using Iot_Management_System.Models;
using System.Net.Http;
using Newtonsoft.Json;

namespace Iot_Management_System.ViewModal
{
    public class HomeViewModal
    {

      
            private readonly HttpClient client;
            private readonly IClientHelper _clientHelper;
            private readonly IDataProtector _protector;

            public HomeViewModal(IClientHelper clientHelper, IDataProtectionProvider dataProtectionProvider)
            {
                _clientHelper = clientHelper;
                _protector = dataProtectionProvider.CreateProtector("MyCookieEncryptionPurpose");
            }
        public async Task<CommonResponseModel> Add_Sensor(SensorModal sensor)
        {
            CommonResponseModel res = new CommonResponseModel();
            SensorModal sensorModal = new SensorModal
            {
                Sensor_Id = sensor.Sensor_Id,
                SensorCode = sensor.SensorCode,
                SensorName = sensor.SensorName,
                SensorType = sensor.SensorType,
                SensorState = sensor.SensorState,
                Unit = sensor.Unit,
                MinThreshold = sensor.MinThreshold,
                MaxThreshold = sensor.MaxThreshold,

            };
            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;

            HttpClient client = new HttpClient(handler);
            var serializedItemToCreate = JsonConvert.SerializeObject(sensorModal);
            var response = await client.PostAsync("https://localhost:7061/api/Home/Add_Sensor",
                                    new StringContent(serializedItemToCreate,
                                            System.Text.Encoding.Unicode,
                                            "application/json"));

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                res = JsonConvert.DeserializeObject<CommonResponseModel>(content);
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"API call failed with status code: {response.StatusCode}, content: {errorContent}");
            }
            return res;
        }


        //public async Task<List<Country>> GetCountries()
        //{
        //    List<Country> countries = new List<Country>();

        //    HttpClient client = await _clientHelper.PrepareAuthenticatedClient();
        //    var response = await client.GetAsync("https://localhost:7238/api/EmpApi/Get_Countries", HttpCompletionOption.ResponseContentRead);

        //    if (response.IsSuccessStatusCode)
        //    {
        //        var content = await response.Content.ReadAsStringAsync();
        //        countries = JsonConvert.DeserializeObject<List<Country>>(content);
        //    }
        //    return countries;
        //}

        //public async Task<CommonResponseModel> Insert_MasterCountry(int id)
        //{
        //    CommonResponseModel res = new CommonResponseModel();
        //    //CountryMasterViewModal ctry = new CountryMasterViewModal
        //    //{
        //    //    CountryMasterId = country.CountryMasterId,
        //    //};
        //    //CountryMasterViewModal ctry = new CountryMasterViewModal();


        //    string url = $"https://localhost:7238/api/EmpApi/MasterCountry_Insert?id={id}";

        //    HttpClientHandler handler = new HttpClientHandler();
        //    handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;

        //    HttpClient client = new HttpClient(handler);
        //    var serializedItemToCreate = JsonConvert.SerializeObject(id);
        //    var response = await client.PostAsync(url,
        //                            new StringContent(serializedItemToCreate,
        //                                    System.Text.Encoding.Unicode,
        //                                    "application/json"));



        //    if (response.IsSuccessStatusCode)
        //    {
        //        var content = await response.Content.ReadAsStringAsync();
        //        res = JsonConvert.DeserializeObject<CommonResponseModel>(content);
        //    }
        //    else
        //    {
        //        var errorContent = await response.Content.ReadAsStringAsync();
        //        throw new Exception($"API call failed with status code: {response.StatusCode}, content: {errorContent}");
        //    }
        //    return res;
        //}


        //public async Task<List<CountryMasterViewModal>> GetMasterCountries()
        //{
        //    List<CountryMasterViewModal> countries = new List<CountryMasterViewModal>();

        //    HttpClient client = await _clientHelper.PrepareAuthenticatedClient();
        //    var response = await client.GetAsync("https://localhost:7238/api/EmpApi/Get_MasterCountries", HttpCompletionOption.ResponseContentRead);

        //    if (response.IsSuccessStatusCode)
        //    {
        //        var content = await response.Content.ReadAsStringAsync();
        //        countries = JsonConvert.DeserializeObject<List<CountryMasterViewModal>>(content);
        //    }
        //    return countries;
        //}


        //public async Task<List<State>> GetStates(int CountryId)
        //{
        //    List<State> states = new List<State>();

        //    HttpClient client = await _clientHelper.PrepareAuthenticatedClient();
        //    string url = $"https://localhost:7238/api/EmpApi/Get_States?CountryId={CountryId}";

        //    var response = await client.GetAsync(url, HttpCompletionOption.ResponseContentRead);
        //    if (response.IsSuccessStatusCode)
        //    {
        //        var content = await response.Content.ReadAsStringAsync();
        //        states = JsonConvert.DeserializeObject<List<State>>(content);
        //    }
        //    return states;
        //}

        //public async Task<List<City>> GetCities(int StateId)
        //{
        //    List<City> cities = new List<City>();

        //    HttpClient client = await _clientHelper.PrepareAuthenticatedClient();
        //    string url = $"https://localhost:7238/api/EmpApi/Get_Cities?StateId={StateId}";

        //    var response = await client.GetAsync(url, HttpCompletionOption.ResponseContentRead);
        //    if (response.IsSuccessStatusCode)
        //    {
        //        var content = await response.Content.ReadAsStringAsync();
        //        cities = JsonConvert.DeserializeObject<List<City>>(content);
        //    }
        //    return cities;
        //}


        //public async Task<List<GetEmployee>> GetEmployees()
        //{
        //    List<GetEmployee> res = new List<GetEmployee>();

        //    HttpClient client = await _clientHelper.PrepareAuthenticatedClient();
        //    var response = await client.GetAsync("https://localhost:7238/api/EmpApi/GetEmployees", HttpCompletionOption.ResponseContentRead);

        //    if (response.IsSuccessStatusCode)
        //    {
        //        var content = await response.Content.ReadAsStringAsync();
        //        res = JsonConvert.DeserializeObject<List<GetEmployee>>(content);
        //    }

        //    return res;
        //}



        //public async Task<CommonResponseModel> UpdateEmployee(EmployeeModal emp)
        //{
        //    CommonResponseModel res = new CommonResponseModel();
        //    HttpClientHandler handler = new HttpClientHandler();
        //    handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;
        //    HttpClient client = new HttpClient(handler);
        //    var serializedItemToCreate = JsonConvert.SerializeObject(emp);
        //    var response = await client.PutAsync("https://localhost:7238/api/EmpApi/UpdateEmployees",
        //                    new StringContent(serializedItemToCreate,
        //                            System.Text.Encoding.Unicode,
        //                            "application/json"));


        //    if (response.IsSuccessStatusCode)
        //    {
        //        var content = await response.Content.ReadAsStringAsync();
        //        res = JsonConvert.DeserializeObject<CommonResponseModel>(content);
        //    }
        //    else
        //    {
        //        var errorContent = await response.Content.ReadAsStringAsync();
        //        throw new Exception($"API call failed with status code: {response.StatusCode}, content: {errorContent}");
        //    }
        //    return res;
        //}


        //public async Task<CommonResponseModel> DeleteEmployees(int id)
        //{
        //    CommonResponseModel res = new CommonResponseModel();

        //    HttpClient client = await _clientHelper.PrepareAuthenticatedClient();
        //    var serializedItemToCreate = JsonConvert.SerializeObject(id);
        //    string url = $"https://localhost:7238/api/EmpApi/DeleteEmployees?id={id}";
        //    var response = await client.PostAsync(url,
        //                            new StringContent(serializedItemToCreate,
        //                                    System.Text.Encoding.Unicode,
        //                                    "application/json"));
        //    if (response.IsSuccessStatusCode)
        //    {
        //        var content = await response.Content.ReadAsStringAsync();
        //        res = JsonConvert.DeserializeObject<CommonResponseModel>(content);
        //    }
        //    return res;
        //}



        //public async Task<CommonResponseModel> AdminLogin(string Email, string Password, int usertype)
        //{
        //    CommonResponseModel res = new CommonResponseModel();
        //    try
        //    {
        //        var requestUrl = $"https://localhost:7238/api/Admin/AdminLogin?email={Email}&password={Password}&usertype={usertype}";

        //        HttpClientHandler handler = new HttpClientHandler();
        //        handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;

        //        using (HttpClient client = new HttpClient(handler))
        //        {
        //            var response = await client.GetAsync(requestUrl, HttpCompletionOption.ResponseContentRead);

        //            if (response.IsSuccessStatusCode)
        //            {
        //                var content = await response.Content.ReadAsStringAsync();
        //                res = JsonConvert.DeserializeObject<CommonResponseModel>(content);
        //            }

        //            return res;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"An error occurred: {ex.Message}");
        //        throw;
        //    }
        //}

    }
}
