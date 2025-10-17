namespace Iot_Management_System.Models
{
    public class CommonResponseModel
    {
        public string Code { get; set; }
        public string ResponseData { get; set; }
        public string Message { get; set; }
        public string? Token { get; set; }
        public string? Type { get; set; }
    }
}
