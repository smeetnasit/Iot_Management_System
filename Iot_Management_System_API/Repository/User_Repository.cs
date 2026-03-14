using Dapper;
using Iot_Management_System_API.DTO;
using Iot_Management_System_API.Interface;
using System.Data;

namespace Iot_Management_System_API.Repository
{
    public class User_Repository : IUserRepository
    {
        private readonly DBContext _dbContext;

        public User_Repository(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UserDTO?> GetUserByEmail(string email)
        {
            using (var connection = _dbContext.CreateConnection())
            {
                var param = new DynamicParameters();
                param.Add("@Email", email,DbType.String, ParameterDirection.Input);
                return await connection.QueryFirstOrDefaultAsync<UserDTO>( "Sp_Get_User_By_Email", param, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<List<UserDTO>> GetAllUsers()
        {
            using (var connection = _dbContext.CreateConnection())
            {
                var users = await connection.QueryAsync<UserDTO>("Sp_Get_All_Users",commandType: CommandType.StoredProcedure);
                return users.ToList();
            }
        }

        public async Task UpsertUser(string fullName, string email,string passwordHash, string role, int userId, int isActive = 1)
        {
            using (var connection = _dbContext.CreateConnection())
            {
                var param = new DynamicParameters();
                param.Add("@User_Id", userId, DbType.Int32, ParameterDirection.Input);
                param.Add("@Full_Name", fullName, DbType.String, ParameterDirection.Input);
                param.Add("@Email", email, DbType.String, ParameterDirection.Input);
               // param.Add("@Password_Hash", passwordHash, DbType.String, ParameterDirection.Input);
                param.Add("@Password_Hash",string.IsNullOrEmpty(passwordHash) ? null : passwordHash,DbType.String, ParameterDirection.Input);
                param.Add("@Role", role, DbType.String, ParameterDirection.Input);
                param.Add("@IsActive", isActive, DbType.Int32, ParameterDirection.Input);
                await connection.ExecuteAsync("Sp_Upsert_User", param,commandType: CommandType.StoredProcedure);
            }
        }
        public async Task DeleteUser(int userId)
        {
            using (var connection = _dbContext.CreateConnection())
            {
                var param = new DynamicParameters();
                param.Add("@User_Id", userId,DbType.Int32, ParameterDirection.Input);
                await connection.ExecuteAsync("Sp_Delete_User", param,commandType: CommandType.StoredProcedure);
            }
        }
    }
}