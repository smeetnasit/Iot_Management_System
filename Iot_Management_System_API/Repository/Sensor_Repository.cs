using Dapper;
using Iot_Management_System_API.DTO;
using Iot_Management_System_API.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Iot_Management_System_API.Repository
{
    public class Sensor_Repository : ISensor
    {
        private readonly DBContext _dBContext;
        private readonly IConfiguration _configuration;
        public Sensor_Repository(DBContext dBContext, IConfiguration configuration)
        {
            _dBContext = dBContext;
            _configuration = configuration;
        }


        public async Task<CommonResponse> Add_Sensor(Sensor sensor)
        {
            using (var connection = _dBContext.CreateConnection())
            {
                // Console.WriteLine("✅ Connected Successfully!");

                try
                {
                    CommonResponse commonResponse = new CommonResponse();

                    DynamicParameters param = new DynamicParameters();


                    param.Add("@Sensor_Id", sensor.Sensor_Id, DbType.Int32, ParameterDirection.Input);
                    param.Add("@SensorUnitId", sensor.SensorUnitId, DbType.Int32, ParameterDirection.Input);
                   // param.Add("@Sensor_Name", sensor.Sensor_Name, DbType.String, ParameterDirection.Input);
                    param.Add("@Sensor_Code", sensor.Sensor_Code, DbType.String, ParameterDirection.Input);
                    param.Add("@Sensor_State", sensor.Sensor_State, DbType.Int32, ParameterDirection.Input);
                    param.Add("@MinThreshold", sensor.MinThreshold, DbType.Double, ParameterDirection.Input);
                    param.Add("@MaxThreshold", sensor.MaxThreshold, DbType.Double, ParameterDirection.Input);



                    var task = connection.QueryMultiple("Sp_Sensor_Upsert", param, commandTimeout: 600, commandType: CommandType.StoredProcedure);
                    return task.Read<CommonResponse>().FirstOrDefault();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }


        public async Task<List<Sensor_Units>> Get_Sensor_Units()
        {
            using (var connection = _dBContext.CreateConnection())
            {

                try
                {
                    var items = await connection.QueryAsync<Sensor_Units>("Sp_Get_Sensor_Units", commandType: CommandType.StoredProcedure);
                    return items.ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                    throw;
                }
            }
        }

        public async Task<List<Sensor>> GetSensorsData()
        {
            using (var connection = _dBContext.CreateConnection())
            {
                try
                {
                    var items = await connection.QueryAsync<Sensor>("Sp_Get_Sensors_Data", commandType: CommandType.StoredProcedure);
                    return items.ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                    throw;
                }
            }

        }
        public async Task<CommonResponse> DeleteSensorsData(int id)
        {
            using (var connection = _dBContext.CreateConnection())
            {

                try
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@Id", id, dbType: DbType.Int64, direction: ParameterDirection.Input);
                    param.Add("@DeletedBy", 0, dbType: DbType.Int64, direction: ParameterDirection.Input);

                    var task = connection.QueryMultiple("Sp_Delete_Sensors_Data", param, commandTimeout: 600, commandType: CommandType.StoredProcedure);
                    return task.Read<CommonResponse>().FirstOrDefault();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public async Task<List<SensorReading>> GetLatestReadings()
        {
            using (var connection = _dBContext.CreateConnection())
            {
                try
                {
                    var readings = await connection
                        .QueryAsync<SensorReading>("Sp_Get_Latest_Readings",commandType: CommandType.StoredProcedure);
                    return readings.ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                    throw;
                }
            }
        }

        public async Task<List<SensorReading>> GetAlertReadings()
        {
            using (var connection = _dBContext.CreateConnection())
            {
                var readings = await connection.QueryAsync<SensorReading>("Sp_Get_Alert_Readings",commandType: CommandType.StoredProcedure);
                return readings.ToList();
            }
        }

        public async Task<bool> UpdateAlertStatus(int readingId, string status)
        {
            using (var connection = _dBContext.CreateConnection())
            {
                var param = new DynamicParameters();
                param.Add("@Reading_Id", readingId,DbType.Int32, ParameterDirection.Input);
                param.Add("@Alert_Status", status,DbType.String, ParameterDirection.Input);

                var affectedRows = await connection.ExecuteScalarAsync<int>("Sp_Update_Alert_Status",param,commandType: CommandType.StoredProcedure);

                return affectedRows > 0;
            }
        }

        public async Task<List<SensorReport>> GetSensorReport()
        {
            using (var connection = _dBContext.CreateConnection())
            {
                var report = await connection.QueryAsync<SensorReport>("Sp_Get_Sensor_Report",commandType: CommandType.StoredProcedure);
                return report.ToList();
            }
        }

       

       
      



    }

    


}
