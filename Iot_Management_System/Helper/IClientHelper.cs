namespace Iot_Management_System.Hepler
{
    public interface IClientHelper
    {
        Task<HttpClient> PrepareAuthenticatedClient();
        Task<HttpClient> PreparePatientCommAuthenticatedClient(string scope);
    }
}