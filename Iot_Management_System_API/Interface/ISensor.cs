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
        Task<List<SensorReading>> GetLatestReadings();


        //public Task<CommonResponse> Emp_Update(Sensor emp);
        //public Task<CommonResponse> AdminLogin(string email, string password, int usertype);


    }
}
