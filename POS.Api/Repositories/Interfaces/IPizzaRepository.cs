using POS.Api.Data.DbModels;

namespace POS.Api.Repositories.Interfaces
{
    public interface IPizzaRepository: IRepository<Pizza>
    {
        void AddPizza(Pizza Pizza);
        void UpdatePizza(Pizza Pizza);
        void DeletePizza(int PizzaId);
        Task<IEnumerable<Pizza>> GetPizzas();
        Task<Pizza?> GetPizzaById(int id);
        void Save();
    }
}
