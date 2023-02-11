using POS.Api.Data.Enums;

namespace POS.Api.DTOs.Request
{
    public class ToppingsRequest: AddonRequest
    {
        public ToppingType Type { get; set; }
    }
}
