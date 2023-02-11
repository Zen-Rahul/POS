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

        public void AddItem(Item Item)
        {
            Context.Items.Add(Item);
        }

        public void DeleteItem(int ItemId)
        {
            var Item = Context.Items.FindAsync(ItemId);
            Context.Remove(Item);
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

        public void UpdateItem(Item Item)
        {
            Context.Entry(Item).State = EntityState.Modified;
        }

        public void Save()
        {
            Context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
