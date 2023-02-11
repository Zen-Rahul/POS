using POS.Api.Data.DbModels.BaseModels;
using POS.Api.Data.Enums;

namespace POS.Api
{
    public class Sauce: Addons
    {
        public SauceType Type { get; set; }
    }
}