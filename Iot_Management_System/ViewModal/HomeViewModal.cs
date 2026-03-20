using Iot_Management_System.Hepler;
using Iot_Management_System.Models;
using Microsoft.AspNetCore.DataProtection;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

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
                SensorUnitId = sensor.SensorUnitId,  
                Sensor_Code = sensor.Sensor_Code,
                Sensor_Name = sensor.Sensor_Name,
                Sensor_State = sensor.Sensor_State,
                MinThreshold = sensor.MinThreshold,
                MaxThreshold = sensor.MaxThreshold,

            };
            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;

            HttpClient client = new HttpClient(handler);
            var serializedItemToCreate = JsonConvert.SerializeObject(sensorModal);
            var response = await client.PostAsync("https://app-iot-api-dev-f5fvhxbpagezbrhb.westus2-01.azurewebsites.net/api/Home/Add_Sensor",
                                   new StringContent(serializedItemToCreate,
                                   System.Text.Encoding.UTF8, "application/json")
                                    );

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



        public async Task<List<Sensor_Units>> Get_Sensor_Units()
        {
            List<Sensor_Units> units = new List<Sensor_Units>();

            HttpClient client = await _clientHelper.PrepareAuthenticatedClient();
            var response = await client.GetAsync("https://app-iot-api-dev-f5fvhxbpagezbrhb.westus2-01.azurewebsites.net/api/Home/Get_Sensor_Units", HttpCompletionOption.ResponseContentRead);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                units = JsonConvert.DeserializeObject<List<Sensor_Units>>(content);
            }
            return units;
        }


        public async Task<List<SensorModal>> GetSensorsData()
        {
            List<SensorModal> res = new List<SensorModal>();

            HttpClient client = await _clientHelper.PrepareAuthenticatedClient();
            var response = await client.GetAsync("https://app-iot-api-dev-f5fvhxbpagezbrhb.westus2-01.azurewebsites.net/api/Home/GetSensorsData", HttpCompletionOption.ResponseContentRead);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                res = JsonConvert.DeserializeObject<List<SensorModal>>(content);
            }

            return res;
        }


        public async Task<CommonResponseModel> DeleteSensorsData(int id)
        {
            CommonResponseModel res = new CommonResponseModel();

            HttpClient client = await _clientHelper.PrepareAuthenticatedClient();
            var serializedItemToCreate = JsonConvert.SerializeObject(id);
            string url = $"https://app-iot-api-dev-f5fvhxbpagezbrhb.westus2-01.azurewebsites.net/api/Home/DeleteSensorsData?id={id}";
            var response = await client.PostAsync(url,
                                    new StringContent(serializedItemToCreate,
                                            System.Text.Encoding.Unicode,
                                            "application/json"));
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                res = JsonConvert.DeserializeObject<CommonResponseModel>(content);
            }
            return res;
        }


        

    }
}
