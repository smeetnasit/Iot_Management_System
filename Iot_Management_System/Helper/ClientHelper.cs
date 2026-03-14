using Microsoft.Net.Http.Headers;

namespace Iot_Management_System.Hepler
{
    public class ClientHelper : IClientHelper
    {
        private HttpClient _httpClient;

        public ClientHelper()
        {
        }

        public async Task<HttpClient> PrepareAuthenticatedClient()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add(
                HeaderNames.Accept, "application/json");
            return _httpClient;
        }

        public Task<HttpClient> PreparePatientCommAuthenticatedClient(
            string scope)
        {
            throw new NotImplementedException();
        }
    }
}