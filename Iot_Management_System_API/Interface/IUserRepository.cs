using Iot_Management_System_API.DTO;

namespace Iot_Management_System_API.Interface
{
    public interface IUserRepository
    {
        Task<UserDTO?> GetUserByEmail(string email);
        Task<List<UserDTO>> GetAllUsers();
        Task UpsertUser(string fullName, string email,
            string passwordHash, string role, int userId, int isActive);
        Task DeleteUser(int userId);
    }
}