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
                Console.WriteLine("✅ Connected Successfully!");

                try
                {
                    CommonResponse commonResponse = new CommonResponse();

                    DynamicParameters param = new DynamicParameters();

                    param.Add("@SensorName", sensor.SensorName, dbType: DbType.String, direction: ParameterDirection.Input);
                    param.Add("@SensorCode", sensor.SensorCode, dbType: DbType.String, direction: ParameterDirection.Input);
                    param.Add("@State", sensor.State, dbType: DbType.Int64, direction: ParameterDirection.Input);
                    //param.Add("@Created_By", sensor.State, dbType: DbType.Int64, direction: ParameterDirection.Input);
                    //param.Add("@Updated_By", sensor.State, dbType: DbType.Int64, direction: ParameterDirection.Input);
                    //param.Add("@Deleted_By", sensor.State, dbType: DbType.Int64, direction: ParameterDirection.Input);
                   


                    var task = connection.QueryMultiple("Sp_Sensor_Upsert", param, commandTimeout: 600, commandType: CommandType.StoredProcedure);
                    return task.Read<CommonResponse>().FirstOrDefault();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        //public async Task<CommonResponse> MasterCountryInsert(int id)
        //{
        //    using (var connection = _dBContext.CreateConnection())
        //    {
        //        try
        //        {
        //            CommonResponse commonResponse = new CommonResponse();

        //            DynamicParameters param = new DynamicParameters();

        //             param.Add("@MasterCountryId", id, dbType: DbType.String, direction: ParameterDirection.Input);



        //            var task = connection.QueryMultiple("Proc_CountryMaster_Add", param, commandTimeout: 600, commandType: CommandType.StoredProcedure);
        //            return task.Read<CommonResponse>().FirstOrDefault();
        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;
        //        }
        //    }
        //}




        //public async Task<List<Country>> GetCountries()
        //{
        //    using (var connection = _dBContext.CreateConnection())
        //    {

        //        try
        //        {
        //            var items = await connection.QueryAsync<Country>("Proc_Smeet_GetCountries", commandType: CommandType.StoredProcedure);
        //            return items.ToList();
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine($"An error occurred: {ex.Message}");
        //            throw;
        //        }
        //    }
        //}


        //public async Task<List<CountryMaster>> GetMasterCountries()
        //{
        //    using (var connection = _dBContext.CreateConnection())
        //    {

        //        try
        //        {
        //            var items = await connection.QueryAsync<CountryMaster>("Proc_Smeet_GetMasterCountries", commandType: CommandType.StoredProcedure);
        //            return items.ToList();
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine($"An error occurred: {ex.Message}");
        //            throw;
        //        }
        //    }
        //}

        //public async Task<List<State>> GetStates(int CountryId)
        //{
        //    using (var connection = _dBContext.CreateConnection())
        //    {

        //        try
        //        {
        //            DynamicParameters param = new DynamicParameters();
        //            param.Add("@CountryId", CountryId, dbType: DbType.Int64, direction: ParameterDirection.Input);
        //            var items = await connection.QueryAsync<State>("Proc_Smeet_GetStates",param, commandType: CommandType.StoredProcedure);
        //            return items.ToList();
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine($"An error occurred: {ex.Message}");
        //            throw;
        //        }
        //    }
        //}


        //public async Task<List<City>> GetCities(int StateId)
        //{
        //    using (var connection = _dBContext.CreateConnection())
        //    {

        //        try
        //        {
        //            DynamicParameters param = new DynamicParameters();
        //            param.Add("@StateId", StateId, dbType: DbType.Int64, direction: ParameterDirection.Input);
        //            var items = await connection.QueryAsync<City>("Proc_Smeet_GetCities", param, commandType: CommandType.StoredProcedure);
        //            return items.ToList();
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine($"An error occurred: {ex.Message}");
        //            throw;
        //        }
        //    }
        //}


        //public async Task<List<GetEmployee>> GetEmployees()
        //{
        //    using (var connection = _dBContext.CreateConnection())
        //    {
        //        try
        //        {
        //            var items = await connection.QueryAsync<GetEmployee>("Proc_Smeet_GetAllEmployees", commandType: CommandType.StoredProcedure);
        //            return items.ToList();
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine($"An error occurred: {ex.Message}");
        //            throw;
        //        }
        //    }

        //}

        //public async Task<CommonResponse> Emp_Update(Sensor emp)
        //{
        //    using (var connection = _dBContext.CreateConnection())
        //    {

        //        try
        //        {
        //            DynamicParameters param = new DynamicParameters();
        //            param.Add("@Id", emp.Id, dbType: DbType.Int64, direction: ParameterDirection.Input);
        //            param.Add("@EmpCode", emp.EmpCode, dbType: DbType.String, direction: ParameterDirection.Input);
        //            param.Add("@EmpName", emp.EmpName, dbType: DbType.String, direction: ParameterDirection.Input);
        //            param.Add("@Address1", emp.Address1, dbType: DbType.String, direction: ParameterDirection.Input);
        //            param.Add("@Address2", emp.Address2, dbType: DbType.String, direction: ParameterDirection.Input);
        //            param.Add("@Country", emp.Country, dbType: DbType.Int64, direction: ParameterDirection.Input);
        //            param.Add("@State", emp.State, dbType: DbType.Int64, direction: ParameterDirection.Input);
        //            param.Add("@City", emp.City, dbType: DbType.Int64, direction: ParameterDirection.Input);
        //            param.Add("@MobileNo", emp.MobileNo, dbType: DbType.Int64, direction: ParameterDirection.Input);
        //            param.Add("@PhoneNo", emp.PhoneNo, dbType: DbType.Int64, direction: ParameterDirection.Input);
        //            param.Add("@Email", emp.Email, dbType: DbType.String, direction: ParameterDirection.Input);
        //            param.Add("@EmpDesignation", emp.EmpDesignation, dbType: DbType.String, direction: ParameterDirection.Input);
        //            param.Add("@EmpSalary", emp.EmpSalary, dbType: DbType.Int64, direction: ParameterDirection.Input);

        //            var task = connection.QueryMultiple("Proc_Tbl_Emp_Update", param, commandTimeout: 600, commandType: CommandType.StoredProcedure);
        //            return task.Read<CommonResponse>().FirstOrDefault();
        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;
        //        }
        //    }
        //}


        //public async Task<CommonResponse> DeleteEmployees(int id)
        //{
        //    using (var connection = _dBContext.CreateConnection())
        //    {

        //        try
        //        {
        //            DynamicParameters param = new DynamicParameters();
        //            param.Add("@Id",id, dbType: DbType.Int64, direction: ParameterDirection.Input);

        //            var task = connection.QueryMultiple("Proc_Tbl_Emp_Delete", param, commandTimeout: 600, commandType: CommandType.StoredProcedure);
        //            return task.Read<CommonResponse>().FirstOrDefault();
        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;
        //        }
        //    }
        //}


        //public async Task<CommonResponse> AdminLogin(string email, string password,int usertype)
        //{
        //    using (var connection = _dBContext.CreateConnection())
        //    {
        //        try
        //        {
        //            DynamicParameters param = new DynamicParameters();
        //            param.Add("@Email", email, dbType: DbType.String, direction: ParameterDirection.Input);
        //            param.Add("@Password", password, dbType: DbType.String, direction: ParameterDirection.Input);
        //            param.Add("@Usertype", usertype, dbType: DbType.Int64, direction: ParameterDirection.Input);


        //            var task = connection.QueryMultiple("Proc_SmeetAdminLogin", param, commandTimeout: 600, commandType: CommandType.StoredProcedure);
        //            return task.Read<CommonResponse>().FirstOrDefault();
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine(ex);
        //            throw;
        //        }

        //    }
        //}


        //public async Task<CommonResponse> InsertExcelEmployee(GetExcelEmployee emp)
        //{
        //    using (var connection = _dBContext.CreateConnection()) // Adjust to your DB connection method
        //    {
        //        try
        //        {
        //            var param = new DynamicParameters();
        //            param.Add("@Id", emp.Id, dbType: DbType.Int64, direction: ParameterDirection.Input);
        //            param.Add("@EmpName", emp.EmpName, dbType: DbType.String, direction: ParameterDirection.Input);
        //            param.Add("@Address1", emp.Address1, dbType: DbType.String, direction: ParameterDirection.Input);
        //            param.Add("@Address2", emp.Address2, dbType: DbType.String, direction: ParameterDirection.Input);
        //            param.Add("@Country", emp.Country, dbType: DbType.Int64, direction: ParameterDirection.Input);
        //            param.Add("@State", emp.State, dbType: DbType.Int64, direction: ParameterDirection.Input);
        //            param.Add("@City", emp.City, dbType: DbType.Int64, direction: ParameterDirection.Input);
        //            param.Add("@MobileNo", emp.MobileNo, dbType: DbType.Int64, direction: ParameterDirection.Input);
        //            param.Add("@PhoneNo", emp.PhoneNo, dbType: DbType.Int64, direction: ParameterDirection.Input);
        //            param.Add("@Email", emp.Email, dbType: DbType.String, direction: ParameterDirection.Input);
        //            param.Add("@EmpDesignation", emp.EmpDesignation, dbType: DbType.String, direction: ParameterDirection.Input);
        //            param.Add("@EmpSalary", emp.EmpSalary, dbType: DbType.Int64, direction: ParameterDirection.Input);
        //            param.Add("@password", emp.Password, dbType: DbType.String, direction: ParameterDirection.Input);

        //            var task = connection.QueryMultiple("Proc_ExcelData_Insert", param, commandTimeout: 600, commandType: CommandType.StoredProcedure);
        //            return task.Read<CommonResponse>().FirstOrDefault();
        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;
        //        }
        //    }
        //}
    }
}
