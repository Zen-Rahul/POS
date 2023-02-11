using POS.Api.Data.DbModels.BaseModels;
using POS.Api.Data.Enums;

namespace POS.Api
{
    public class Topping: Addons
    {
        public ToppingType Type { get; set; }
    }
}