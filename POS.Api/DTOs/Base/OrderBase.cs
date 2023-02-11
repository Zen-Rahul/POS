using POS.Api.DTOs.Request;

namespace POS.Api.DTOs.Base
{
    public class OrderBase
    {
        public List<PizzaRequest> Pizzas { get; set; }
        public UserRequest User { get; set; }
    }
}
