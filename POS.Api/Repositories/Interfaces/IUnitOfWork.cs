namespace POS.Api.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IItemRepository ItemRepository { get; }
        IOrderRepository OrderRepository { get; }
        IPizzaRepository PizzaRepository { get; }
        Task<int> SaveAsync();
    }
}