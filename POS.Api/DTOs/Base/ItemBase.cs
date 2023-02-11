using POS.Api.Data.Enums;

namespace POS.Api.DTOs.Base
{
    public abstract class ItemBase
    {
        public PizzaSize Size { get; set; }

        public decimal Price { get; set; }
    }
}
