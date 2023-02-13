using Microsoft.EntityFrameworkCore;
using POS.Api.Data;
using POS.Api.Data.DbModels;
using POS.Api.Repositories.Base;
using POS.Api.Repositories.Interfaces;

namespace POS.Api.Repositories
{
    public class PizzaRepository : Repository<Pizza>, IPizzaRepository
    {
        public PizzaRepository(POSContext context) : base(context)
        {
        }

        public void AddPizza(Pizza Pizza)
        {
            Context.Pizzas.Add(Pizza);
        }

        public void DeletePizza(int PizzaId)
        {
            var Pizza = Context.Pizzas.FindAsync(PizzaId);
            Context.Remove(Pizza);
        }

        public async Task<Pizza?> GetPizzaById(int id)
        {
            return await Context.Pizzas.FindAsync(id);
        }

        public async Task<IEnumerable<Pizza>> GetPizzas()
        {
            return await Context.Pizzas.ToListAsync();
        }

        public void UpdatePizza(Pizza Pizza)
        {
            Context.Entry(Pizza).State = EntityState.Modified;
        }

        private bool _disposed = false;

        protected override void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
            }
            _disposed = true;
        }
    }
}
