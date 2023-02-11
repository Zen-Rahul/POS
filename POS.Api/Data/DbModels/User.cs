using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POS.Api.Data.DbModels
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(10),MinLength(10)]
        public string MobileNumber { get; set; }

        [Required]

        public string DeliveryAddress { get; set; }

        public virtual ICollection<Pizza> Pizzas { get; set; }
    }
}
