using Iot_Management_System.Hepler;
using Iot_Management_System.Models;
using Newtonsoft.Json;

namespace Iot_Management_System.ViewModal
{
    public class UsersViewModal
    {
        private readonly IClientHelper _clientHelper;

        public UsersViewModal(IClientHelper clientHelper)
        {
            _clientHelper = clientHelper;
        }

        public async Task<List<UserModel>> GetAllUsers()
        {
            List<UserModel> users = new List<UserModel>();

            HttpClient client = await _clientHelper.PrepareAuthenticatedClient();
            var response = await client.GetAsync(
                "https://localhost:7061/api/Users",
                HttpCompletionOption.ResponseContentRead);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                users = JsonConvert.DeserializeObject<List<UserModel>>(content);
            }
            return users;
        }

        public async Task<CommonResponseModel> UpsertUser(UserModel user)
        {
            CommonResponseModel res = new CommonResponseModel();

            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback =
                (sender, cert, chain, sslPolicyErrors) => true;

            HttpClient client = new HttpClient(handler);
            var serialized = JsonConvert.SerializeObject(user);
            var response = await client.PostAsync(
                "https://localhost:7061/api/Users",
                new StringContent(serialized,
                    System.Text.Encoding.UTF8, "application/json"));
            var errorContent = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                res = JsonConvert.DeserializeObject<CommonResponseModel>(content);
            }
            return res;
        }

        public async Task<CommonResponseModel> DeleteUser(int id)
        {
            CommonResponseModel res = new CommonResponseModel();

            HttpClient client = await _clientHelper.PrepareAuthenticatedClient();
            var response = await client.DeleteAsync(
                $"https://localhost:7061/api/Users/{id}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                res = JsonConvert.DeserializeObject<CommonResponseModel>(content);
            }
            return res;
        }
    }
}