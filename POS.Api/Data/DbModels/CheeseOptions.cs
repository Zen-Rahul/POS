using POS.Api.Data.DbModels.BaseModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace POS.Api.Data.DbModels
{
    public class CheeseOptions:Addons
    {
        public decimal ExtraCheesePrice { get; set; }

        public virtual Pizza Pizza { get; set; }

        [ForeignKey(nameof(Pizza))]
        public int PizzaId { get; set; }
    }
}
