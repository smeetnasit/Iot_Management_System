using Dapper;
using System.Data;

namespace Iot_Management_System_Simulation
{
    public class SimulationRepository
    {
        private readonly DBContext _dbContext;
        private readonly ILogger<SimulationRepository> _logger;

        public SimulationRepository(
            DBContext dbContext,
            ILogger<SimulationRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        // Get all active sensors
        public async Task<List<ActiveSensor>> GetActiveSensors()
        {
            using (var connection = _dbContext.CreateConnection())
            {
                try
                {
                    var sensors = await connection.QueryAsync<ActiveSensor>("Sp_Get_Sensors_Data",commandType: CommandType.StoredProcedure);
                    return sensors.ToList();
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Error getting sensors: {ex.Message}");
                    return new List<ActiveSensor>();
                }
            }
        }

        // Insert one reading
        public async Task InsertReading(SensorReading reading)
        {
            using (var connection = _dbContext.CreateConnection())
            {
                try
                {
                    var param = new DynamicParameters();
                    param.Add("@Sensor_Id", reading.Sensor_Id,DbType.Int32, ParameterDirection.Input);
                    param.Add("@Reading_Value", reading.Reading_Value,DbType.Double, ParameterDirection.Input);
                    param.Add("@Is_Alert", reading.Is_Alert,DbType.Boolean, ParameterDirection.Input);

                    await connection.ExecuteAsync("Sp_Insert_Sensor_Reading",param,commandType: CommandType.StoredProcedure);
                }
                catch (Exception ex)
                {
                    _logger.LogError(
                        $"Error inserting reading for sensor " +
                        $"{reading.Sensor_Id}: {ex.Message}");
                }
            }
        }
    }
}