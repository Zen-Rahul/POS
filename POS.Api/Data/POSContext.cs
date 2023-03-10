using Microsoft.EntityFrameworkCore;
using POS.Api.Data.DbModels;

namespace POS.Api.Data
{
    public class POSContext : DbContext
    {
        protected POSContext()
        {
        }

        public POSContext(DbContextOptions<POSContext> options) : base(options) { }

        public DbSet<Item> Items { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<CheeseOptions> CheeseOptions { get; set; }
        public DbSet<Sauce> Sauces { get; set; }
        public DbSet<Topping> Toppings { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
