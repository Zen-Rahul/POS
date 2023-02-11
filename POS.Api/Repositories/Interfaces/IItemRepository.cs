using POS.Api.Data.DbModels;
using POS.Api.Data.Enums;

namespace POS.Api.Repositories.Interfaces
{
    public interface IItemRepository: IRepository<Item>
    {
        Task AddItem(Item item);
        Task UpdateItem(Item item);
        Task DeleteItem(int itemId);
        Task<IEnumerable<Item>> GetItems();
        Task<IEnumerable<Item>> GetItems(InventoryType inventoryType);
        Task<Item?> GetItemById(int id);
    }
}
