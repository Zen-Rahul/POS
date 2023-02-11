namespace POS.Api.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IItemRepository ItemRepository { get; }
        IPizzaRepository PizzaRepository { get; }
        Task<int> SaveAsync();
    }
}