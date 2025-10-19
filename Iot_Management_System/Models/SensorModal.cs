namespace Iot_Management_System.Models
{
    public class SensorModal
    {
        public int Sensor_Id { get; set; }          // match DB and SP name
        public string? SensorCode { get; set; }
        public string? SensorName { get; set; }
        public string? SensorType { get; set; }
        public string? Unit { get; set; }
        public int? SensorState { get; set; }
        public double? MinThreshold { get; set; }   // for decimal values
        public double? MaxThreshold { get; set; }   // for decimal values
    }





    public class GetEmployee
    {
        public long Id { get; set; }

        public string? EmpCode { get; set; }


        public string? EmpName { get; set; }

        public string? Address1 { get; set; }

        public string? Address2 { get; set; }

        public string? Country { get; set; }
        public long? CountryId { get; set; }

        public string? State { get; set; }
        public long? StateId { get; set; }

        public string? City { get; set; }
        public long? CityId { get; set; }

        public long? MobileNo { get; set; }

        public long? PhoneNo { get; set; }

        public string? Email { get; set; }
        public long? IsDeleted { get; set; }

        public string? EmpDesignation { get; set; }
        public long? EmpSalary { get; set; }


    }


 
}
