namespace Iot_Management_System_API.DTO
{
    public class SensorReport
    {
        public int Sensor_Id { get; set; }
        public string? Sensor_Name { get; set; }
        public string? Sensor_Code { get; set; }
        public string? Sensor_Unit { get; set; }
        public int Total_Readings { get; set; }
        public int Alert_Count { get; set; }
        public int Normal_Count { get; set; }
        public decimal Alert_Percentage { get; set; }
        public double? Avg_Value { get; set; }
        public double? Min_Value { get; set; }
        public double? Max_Value { get; set; }
    }
}