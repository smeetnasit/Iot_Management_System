namespace Iot_Management_System_API.DTO
{
    public class SensorReading
    {
        public int Reading_Id { get; set; }
        public int Sensor_Id { get; set; }
        public string? Sensor_Name { get; set; }
        public string? Sensor_Code { get; set; }
        public string? Sensor_Unit { get; set; }
        public double? MinThreshold { get; set; }
        public double? MaxThreshold { get; set; }
        public double? Reading_Value { get; set; }
        public DateTime? Reading_Time { get; set; }
        public bool Is_Alert { get; set; }
        public string? Alert_Status { get; set; }  

    }
}
