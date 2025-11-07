using Iot_Management_System_API.DTO;
using System.Diagnostics.Metrics;

namespace Iot_Management_System_API.Interface
{
    public interface ISensor
    {
        public Task<CommonResponse> Add_Sensor(Sensor sensor);
        public Task<List<Sensor_Units>> Get_Sensor_Units();
        public Task<List<Sensor>> GetSensorsData();
        public Task<CommonResponse> DeleteSensorsData(int id);


        //public Task<CommonResponse> InsertExcelEmployee(GetExcelEmployee emp);

        //public Task<CommonResponse> Emp_Update(Sensor emp);
        //public Task<CommonResponse> AdminLogin(string email, string password, int usertype);
        //public Task<List<Country>> GetCountries();
        //public Task<CommonResponse> MasterCountryInsert(int country);
        //public Task<List<CountryMaster>> GetMasterCountries();
        //public Task<List<State>> GetStates(int CountryId);
        //public Task<List<City>> GetCities(int StateId);
        //public Task<List<GetEmployee>> GetEmployees();


    }
}
