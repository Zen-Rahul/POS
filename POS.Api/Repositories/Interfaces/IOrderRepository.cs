using POS.Api.Data.DbModels;
using POS.Api.Data.Enums;

namespace POS.Api.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        Task AddOrder(Order order);
        Task UpdateOrder(Order order);
        Task DeleteOrder(int orderId);
        Task<IEnumerable<Order>> GetOrders();
        Task<Order?> GetOrderById(int id);
    }
}