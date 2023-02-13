using Microsoft.EntityFrameworkCore;
using POS.Api.Data;
using POS.Api.Data.DbModels;
using POS.Api.Repositories.Base;
using POS.Api.Repositories.Interfaces;

namespace POS.Api.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private bool disposed = false;

        public UserRepository(POSContext context) : base(context)
        {
        }

        public Task AddUser(User user)
        {
            return Task.Run(() => Context.Users.Add(user));
        }

        public Task DeleteUser(int userId)
        {
            return Task.Run(() =>
            {
                var user = Context.Users.FindAsync(userId);
                Context.Remove(user);
            });
        }

        public async Task<User?> GetUserById(int id)
        {
            return await Context.Users.FindAsync(id);
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await Context.Users.ToListAsync();
        }

        public Task UpdateUser(User user)
        {
            return Task.Run(() =>
            {
                Context.Entry(user).State = EntityState.Modified;
            });
        }

        protected override void Dispose(bool disposing)
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
    }
}
