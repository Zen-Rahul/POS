using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using POS.Api.Data.Enums;

namespace POS.Api.Data.DbModels
{
    public class Item
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public InventoryType Type { get; set; }

        public PizzaSize Size { get; set; }

        public decimal Price { get; set; }

    }
}
