using POS.Api.Data.Enums;

namespace POS.Api.DTOs.Request
{
    public class SauceRequest : AddonRequest
    {
        public SauceType Type { get; set; }
    }
}
