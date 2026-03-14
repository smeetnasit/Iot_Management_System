namespace Iot_Management_System.Models
{
    public class UserModel
    {
        public int User_Id { get; set; }
        public string? Full_Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Role { get; set; }
        public int IsActive { get; set; }
        public DateTime? Created_Date { get; set; }
    }
}