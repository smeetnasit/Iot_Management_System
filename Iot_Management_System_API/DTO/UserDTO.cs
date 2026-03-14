namespace Iot_Management_System_API.DTO
{
    public class UserDTO
    {
        public int User_Id { get; set; }
        public string? Full_Name { get; set; }
        public string? Email { get; set; }
        public string? Password_Hash { get; set; }
        public string? Role { get; set; }
        public int IsActive { get; set; }
        public DateTime? Created_Date { get; set; }
    }

    public class LoginRequest
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

    public class UpsertUserRequest
    {
        public int User_Id { get; set; }
        public string Full_Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? Password { get; set; } 
        public string Role { get; set; } = string.Empty;
        public int IsActive { get; set; } = 1;
    }
}