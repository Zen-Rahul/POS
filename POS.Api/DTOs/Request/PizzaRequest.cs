using POS.Api.Data.DbModels;
using POS.Api.Data.Enums;

namespace POS.Api.DTOs.Request
{
    public class PizzaRequest
    {
        public PizzaSize Size { get; set; }
        public CrustType Crust { get; set; }
        public List<CheeseRequest>? Cheese { get; set; }
        public List<ToppingsRequest>? Toppings { get; set; }
        public List<SauceRequest>? Sauces { get; set; }
        public decimal BasePrice { get; set; }
    }
}
