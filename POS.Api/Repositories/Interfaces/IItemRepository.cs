using POS.Api.Data.DbModels;
using POS.Api.Data.Enums;

namespace POS.Api.Repositories.Interfaces
{
    public interface IItemRepository: IRepository<Item>
    {
        void AddItem(Item item);
        void UpdateItem(Item item);
        void DeleteItem(int itemId);
        Task<IEnumerable<Item>> GetItems();
        Task<IEnumerable<Item>> GetItems(InventoryType inventoryType);
        Task<Item?> GetItemById(int id);
        void Save();
    }
}
