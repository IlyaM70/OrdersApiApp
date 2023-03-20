using Microsoft.EntityFrameworkCore;
using OrdersApiAppSPD011.Model;
using OrdersApiAppSPD011.Model.Entity;

namespace OrdersApiAppSPD011.Service.ClientService
{
    public class DbDaoClient : IDao<Client>
    {
        private AppDbContext db;

        public DbDaoClient(AppDbContext db)
        {
            this.db = db;
        }

        public async Task<Client> AddAsync(Client client)
        {
            db.Clients.Add(client);
            await db.SaveChangesAsync();
            return client;
        }

        public async Task<Client> DeleteAsync(int id)
        {
            var toDelete = await db.Clients.FindAsync(id);
            if (toDelete != null)
            {
                db.Clients.Remove(toDelete);
                await db.SaveChangesAsync();
                return toDelete;
            }
            else return null;
        }

        public async Task<List<Client>> GetAllAsync()
        {
            return await db.Clients.ToListAsync();
        }

        public async Task<Client> GetAsync(int id)
        {
            return await db.Clients.FindAsync(id);
        }

        public async Task<Client> UpdateAsync(Client client)
        {
            db.Clients.Update(client);
            await db.SaveChangesAsync();
            return client;
        }
    }
}
