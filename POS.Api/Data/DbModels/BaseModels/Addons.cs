using POS.Api.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POS.Api.Data.DbModels.BaseModels
{
    public abstract class Addons
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Required]
        public PizzaSize PizzaSize { get; set; }

        [Required]
        public decimal Price { get; set; }

    }
}