using Microsoft.EntityFrameworkCore;
using POS.Api.Data;
using POS.Api.Data.DbModels;
using POS.Api.Data.Enums;
using POS.Api.Repositories.Base;
using POS.Api.Repositories.Interfaces;

namespace POS.Api.Repositories
{
    public class ItemRepository : Repository<Item>, IItemRepository
    {
        public ItemRepository(POSContext context) : base(context)
        {
        }

        public Task AddItem(Item Item)
        {
            return Task.Run(() => Context.Items.Add(Item));
        }

        public Task DeleteItem(int ItemId)
        {
            return Task.Run(() =>
            {
                var Item = Context.Items.FindAsync(ItemId);
                Context.Remove(Item);
            });
        }

        public async Task<Item?> GetItemById(int id)
        {
            return await Context.Items.FindAsync(id);
        }

        public async Task<IEnumerable<Item>> GetItems()
        {
            return await Context.Items.ToListAsync();
        }

        public async Task<IEnumerable<Item>> GetItems(InventoryType inventoryType)
        {
            return await Context.Items.Where(x => x.Type.Equals(inventoryType)).ToListAsync();
        }

        public Task UpdateItem(Item Item)
        {
            return Task.Run(() =>
            {
                Context.Entry(Item).State = EntityState.Modified;
            });
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
