using Microsoft.Net.Http.Headers;
using System.Globalization;
using System.Net.Http.Headers;

namespace Iot_Management_System.Hepler
{
    public class ClientHelper: IClientHelper
    {

        private HttpClient _httpClient;
        //private readonly ITokenAcquisition _tokenAcquisition;

        private readonly string _APIUrl = string.Empty;
        private readonly string _DLPatientCommClientId = string.Empty;
        private readonly string _DLPatientCommClientSecret = string.Empty;
        private readonly string _Instance = string.Empty;
        private readonly string _Tenant = string.Empty;
        private readonly string _TextConfidential_ApiScope = string.Empty;
        //private readonly string _TextConfidential_ApiBaseAddress = "https://localhost:7233/";
      //  private readonly string _TextConfidential_ApiBaseAddress = "https://TextConfidential-dev.azurewebsites.net/";


        public ClientHelper()
        {
            //_tokenAcquisition = tokenAcquisition;
            ////_APIUrl = configuration["APIUrl"];
            //_DLPatientCommClientId = configuration["DLPatientCommClientId"];
            //_Instance = configuration["Instance"];
            //_Tenant = configuration["Tenant"];

            //_TextConfidential_ApiScope = configuration["TextConfidential_Api:_TextConfidential_ApiScope"];
            //_TextConfidential_ApiBaseAddress = configuration["TextConfidential_Api:_TextConfidential_ApiBaseAddress"];
        }

        public async Task<HttpClient> PrepareAuthenticatedClient()
        {
            //_httpClient = new HttpClient();
            //_httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //_httpClient.BaseAddress = new Uri(_APIUrl);
            //return _httpClient;

            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
            //var accessToken = await _tokenAcquisition.GetAccessTokenForUserAsync(new[] { _TextConfidential_ApiScope });
            //_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            //_httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
         //   _httpClient.BaseAddress = new Uri(_TextConfidential_ApiBaseAddress);
            return _httpClient;

        }

        public Task<HttpClient> PreparePatientCommAuthenticatedClient(string scope)
        {
            throw new NotImplementedException();
        }
    }
}
