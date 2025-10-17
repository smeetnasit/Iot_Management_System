using System.ComponentModel.DataAnnotations;

namespace Iot_Management_System_API.DTO
{
    public class Sensor
    {
        public long Id { get; set; }

        public string? SensorCode { get; set; }


        public string? SensorName { get; set; }

      

        public long? State { get; set; }

      


    }


    public class Country
    {
        public int Id { get; set; }
        public string CountryName { get; set; }
    }


    public class CountryMaster
    {
        public long CountryMasterId { get; set; }
        public string? CountryMasterName { get; set; }
    }

    public class State
    {
        public int Id { get; set; }
        public string StateName { get; set; }
        public int CountryId { get; set; }
    }

    public class City
    {
        public int Id { get; set; }
        public string CityName { get; set; }
        public int StateId { get; set; }
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
        public string? EmpDesignation { get; set; }
        public long? EmpSalary { get; set; }


    }

    public class GetExcelEmployee
    {
        public long Id { get; set; }

        public string? EmpName { get; set; }

        public string? Address1 { get; set; }

        public string? Address2 { get; set; }

        public long? Country { get; set; }

        public long? State { get; set; }

        public long? City { get; set; }

        public long? MobileNo { get; set; }

        public long? PhoneNo { get; set; }

        public string? Email { get; set; }
        public string? EmpDesignation { get; set; }
        public long? EmpSalary { get; set; }
        public string? Password { get; set; }


    }

}
