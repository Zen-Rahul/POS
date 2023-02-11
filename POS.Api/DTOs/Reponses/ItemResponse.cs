using POS.Api.Data.Enums;

namespace POS.Api.DTOs.Reponses
{
    public class ItemResponse
    {
        public string Name { get; set; }

        public PizzaSize Size { get; set; }

        public decimal Price { get; set; }
    }
}
