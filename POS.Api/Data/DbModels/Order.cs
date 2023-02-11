using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POS.Api.Data.DbModels
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        List<Pizza> Pizzas { get; set; }

        public decimal Value { get; set; }
        public User User { get; set; }

        [ForeignKey(nameof(User))]
        public int UserId { get; set; }

    }
}
