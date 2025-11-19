//using Dapper;
//using Emp_API.DTO;
//using Emp_API.Interface;
//using Microsoft.AspNetCore.Mvc;
//using System.Data;
//using static System.Runtime.InteropServices.JavaScript.JSType;

//namespace Emp_API.Repository
//{
//    public class ProfileRepository: IProfile
//    {

//        private readonly DBContext _dBContext;
//        private readonly IConfiguration _configuration;
//        public ProfileRepository(DBContext dBContext, IConfiguration configuration)
//        {
//            _dBContext = dBContext;
//            _configuration = configuration;
//        }

//        public async Task<CommonResponse> ProfileInsert(Profile profile)
//        {
//            using (var connection = _dBContext.CreateConnection())
//            {
//                try
//                {
//                    CommonResponse commonResponse = new CommonResponse();

//                    DynamicParameters param = new DynamicParameters();

//                    param.Add("@EmpCode", profile.EmpCode, dbType: DbType.String, direction: ParameterDirection.Input);
//                    param.Add("@Likes", 0, dbType: DbType.Int64, direction: ParameterDirection.Input);
//                    param.Add("@Comments", 0, dbType: DbType.Int64, direction: ParameterDirection.Input);
//                    param.Add("@Shares", 0, dbType: DbType.Int64, direction: ParameterDirection.Input);
//                    param.Add("@Description", profile.Description, dbType: DbType.String, direction: ParameterDirection.Input);
//                    param.Add("@ProfileLink", profile.ProfileLink_String, dbType: DbType.String, direction: ParameterDirection.Input);
                    


//                    var task = connection.QueryMultiple("Proc_Smeet_Profile_Add", param, commandTimeout: 600, commandType: CommandType.StoredProcedure);
//                    return task.Read<CommonResponse>().FirstOrDefault();
//                }
//                catch (Exception ex)
//                {
//                    throw ex;
//                }
//            }
//        }

//        public async Task<GetEmpProfile> GetEmpProfile(string email)
//        {
//            using (var connection = _dBContext.CreateConnection())
//            {
//                try
//                {

//                    DynamicParameters param = new DynamicParameters();
//                    param.Add("@Email", email, dbType: DbType.String, direction: ParameterDirection.Input);

//                    var users = await connection.QueryFirstOrDefaultAsync<GetEmpProfile>("Proc_Smeet_Get_Emp_Profile", param, commandType: CommandType.StoredProcedure);
//                    return users;

//                    //var task = connection.QueryMultiple("Proc_Smeet_Get_Emp_Profile", param, commandTimeout: 600, commandType: CommandType.StoredProcedure);
//                    //return task.Read<CommonResponse>().FirstOrDefault();
//                }
//                catch (Exception ex)
//                {
//                    throw ex;
//                }
//            }
//        }



//        public async Task<CommonResponse> UpsertProfile(UpsertEmpProfile profile)
//        {
//            using (var connection = _dBContext.CreateConnection())
//            {
//                try
//                {
//                    CommonResponse commonResponse = new CommonResponse();

//                    DynamicParameters param = new DynamicParameters();

//                    param.Add("@Id", profile.Id, dbType: DbType.Int64, direction: ParameterDirection.Input);
//                    param.Add("@EmpCode", profile.EmpCode, dbType: DbType.String, direction: ParameterDirection.Input);
//                    param.Add("@EmpName", profile.EmpName, dbType: DbType.String, direction: ParameterDirection.Input);
//                    param.Add("@Address1", profile.Address1, dbType: DbType.String, direction: ParameterDirection.Input);
//                    param.Add("@Address2", profile.Address2, dbType: DbType.String, direction: ParameterDirection.Input);
//                    param.Add("@Country", profile.Country, dbType: DbType.Int64, direction: ParameterDirection.Input);
//                    param.Add("@State", profile.State, dbType: DbType.Int64, direction: ParameterDirection.Input);
//                    param.Add("@City", profile.City, dbType: DbType.Int64, direction: ParameterDirection.Input);
//                    param.Add("@MobileNo", profile.MobileNo, dbType: DbType.Int64, direction: ParameterDirection.Input);
//                    param.Add("@PhoneNo", profile.PhoneNo, dbType: DbType.Int64, direction: ParameterDirection.Input);
//                    param.Add("@Email", profile.Email, dbType: DbType.String, direction: ParameterDirection.Input);
//                    param.Add("@EmpDesignation", profile.EmpDesignation, dbType: DbType.String, direction: ParameterDirection.Input);
//                  //  param.Add("@Likes", 0, dbType: DbType.Int64, direction: ParameterDirection.Input);
//                  //  param.Add("@Comments", 0, dbType: DbType.Int64, direction: ParameterDirection.Input);
//                  //  param.Add("@Shares", 0, dbType: DbType.Int64, direction: ParameterDirection.Input);
//                    param.Add("@Description", profile.Description, dbType: DbType.String, direction: ParameterDirection.Input);
//                    param.Add("@ProfileLink", profile.ProfileLink_String, dbType: DbType.String, direction: ParameterDirection.Input);



//                    var task = connection.QueryMultiple("Proc_Smeet_Profile_Upsert", param, commandTimeout: 600, commandType: CommandType.StoredProcedure);
//                    return task.Read<CommonResponse>().FirstOrDefault();
//                }
//                catch (Exception ex)
//                {
//                    throw ex;
//                }

//            }
//        }



//        public async Task<CommonResponse> Post_Insert(AddPost postsModel)
//        {
//            using (var connection = _dBContext.CreateConnection())
//            {
//                try
//                {
//                    CommonResponse commonResponse = new CommonResponse();

//                    DynamicParameters param = new DynamicParameters();
//                    param.Add("@EmpId", postsModel.EmpId, dbType: DbType.Int64, direction: ParameterDirection.Input);
//                    param.Add("@PostLink", postsModel.Post_Link_String, dbType: DbType.String, direction: ParameterDirection.Input);
//                    param.Add("@Likes", 0, dbType: DbType.Int64, direction: ParameterDirection.Input);
//                    param.Add("@Comments", 0, dbType: DbType.Int64, direction: ParameterDirection.Input);
//                    param.Add("@Shares", 0, dbType: DbType.Int64, direction: ParameterDirection.Input);
//                    param.Add("@CreatedAt", postsModel.CreatedAt, dbType: DbType.Int64, direction: ParameterDirection.Input);
//                    var task = connection.QueryMultiple("Proc_Smeet_Posts_Add", param, commandTimeout: 600, commandType: CommandType.StoredProcedure);
//                    return task.Read<CommonResponse>().FirstOrDefault();
//                }
//                catch (Exception ex)
//                {
//                    throw ex;
//                }
//            }
//        }

//        public async Task<List<PostsModelDTO>> Get_Post(int empId)
//        {
//            using (var connection = _dBContext.CreateConnection())
//            {
//                try
//                {
//                    List<PostsModelDTO> users = new List<PostsModelDTO>();

//                    DynamicParameters param = new DynamicParameters();
//                    param.Add("@EmpId", empId, dbType: DbType.Int64, direction: ParameterDirection.Input);
//                    var user = await connection.QueryAsync<PostsModelDTO>("Proc_GetUser_Post", param, commandType: CommandType.StoredProcedure);

//                    foreach (var upost in user)
//                    {
//                        users.Add(upost);
//                    }

//                    return users;
//                }
//                catch (Exception ex)
//                {
//                    Console.WriteLine($"An error occurred: {ex.Message}");
//                    throw;
//                }
//            }
//        }


//    }
//}
