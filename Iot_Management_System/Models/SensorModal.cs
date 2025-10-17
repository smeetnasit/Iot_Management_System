namespace Iot_Management_System.Models
{
    public class SensorModal
    {
        public long Id { get; set; }

        public string? SensorCode { get; set; }


        public string? SensorName { get; set; }

        public string? State { get; set; }

    }
  

    public class State
    {
        public int Id { get; set; }
        public string StateName { get; set; }
        public int CountryId { get; set; }
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
