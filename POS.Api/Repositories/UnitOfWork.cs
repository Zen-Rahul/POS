
using POS.Api.Data;
using POS.Api.Repositories.Interfaces;

namespace Assignment.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly POSContext _context;

        public UnitOfWork(POSContext posContext,
            IItemRepository itemRepository,
            IPizzaRepository pizzaRepository,
            IOrderRepository orderRepository)
        {
            _context = posContext;
            ItemRepository = itemRepository;
            PizzaRepository = pizzaRepository;
            OrderRepository = orderRepository;
        }
        public IItemRepository ItemRepository { get; }
        public IPizzaRepository PizzaRepository { get; }
        public IOrderRepository OrderRepository { get; }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                    ItemRepository?.Dispose();
                    PizzaRepository?.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

