using POS.Api.Data.DbModels;
using POS.Api.Data.Enums;

namespace POS.Api.Repositories.Interfaces
{
    public interface IRepository<T>: IDisposable
    {
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAll();
        Task Add(T entity);
        Task Delete(int id);
        Task Delete(T entityToDelete);
        Task Update(T entityToUpdate);
    }
}