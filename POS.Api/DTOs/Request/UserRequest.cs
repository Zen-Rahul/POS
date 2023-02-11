namespace POS.Api.DTOs.Request
{
    public class UserRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public string DeliveryAddress { get; set; }
    }
}
