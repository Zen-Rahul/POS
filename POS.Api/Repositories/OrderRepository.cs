using Microsoft.EntityFrameworkCore;
using POS.Api.Data;
using POS.Api.Data.DbModels;
using POS.Api.Repositories.Base;
using POS.Api.Repositories.Interfaces;

namespace POS.Api.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(POSContext context) : base(context)
        {
        }

        public Task AddOrder(Order order)
        {
            return Task.Run(() => Context.Orders.Add(order));
        }

        public Task DeleteOrder(int orderId)
        {
            return Task.Run(() =>
            {
                var Order = Context.Orders.FindAsync(orderId);
                Context.Remove(Order);
            });
        }

        public async Task<Order?> GetOrderById(int id)
        {
            return await Context.Orders.FindAsync(id);
        }

        public async Task<IEnumerable<Order>> GetOrders()
        {
            return await Context.Orders.ToListAsync();
        }

        public Task UpdateOrder(Order order)
        {
            return Task.Run(() =>
            {
                Context.Entry(order).State = EntityState.Modified;
            });
        }

        public void Save()
        {
            Context.SaveChanges();
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

        public new void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
