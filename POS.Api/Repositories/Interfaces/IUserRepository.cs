using POS.Api.Data.DbModels;
using POS.Api.Data.Enums;

namespace POS.Api.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task AddUser(User user);
        Task UpdateUser(User user);
        Task DeleteUser(int userId);
        Task<IEnumerable<User>> GetUsers();
        Task<User?> GetUserById(int id);
    }
}