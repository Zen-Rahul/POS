using POS.Api.Data.DbModels;

namespace POS.Api.DTOs.Request
{
    public class OrderRequest
    {
        public List<PizzaRequest> Pizzas { get; set; }
        public UserRequest User { get; set; }
    }
}
