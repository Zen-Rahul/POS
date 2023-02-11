using POS.Api.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POS.Api.Data.DbModels
{
    public class Pizza
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Required]
        public PizzaSize Size { get; set; }

        [Required]
        public CrustType Crust { get; set; }
        public List<CheeseOptions>? Cheese { get; set; }
        public List<Topping>? Toppings { get; set; }
        public List<Sauce>? Sauces { get; set; }
        public decimal BasePrice { get; set; }

        public virtual Order Order { get; set; }
        
        [ForeignKey(nameof(Order))]
        public int OrderId { get; set; }
    }
}
