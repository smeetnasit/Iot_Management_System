namespace Iot_Management_System.Models
{
    public class SensorModal
    {
        public int Sensor_Id { get; set; }
        public int? SensorUnitId { get; set; }    
        public string? Sensor_Name { get; set; }
        public string? Sensor_Code { get; set; }
        public string? Sensor_Unit { get; set; }  
        public int? Sensor_State { get; set; }
        public int? IsActive { get; set; }
        public double? MinThreshold { get; set; }
        public double? MaxThreshold { get; set; }
        public string Created_By { get; set; }
        public DateTime? Created_Date { get; set; }
        public string Updated_By { get; set; }
        public DateTime? Updated_Date { get; set; }
        public string Deleted_By { get; set; }
        public DateTime? Deleted_Date { get; set; }
    }

    public class Sensor_Units
    {
        public int SensorID { get; set; }
        public string? SensorName { get; set; }
        public string? MeasuredParameter { get; set; }
        public string? Unit { get; set; }

    }




 
}
