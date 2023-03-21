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
            var deleteClient = await db.Clients.FindAsync(id);
            db.Clients.Remove(deleteClient);

            var delRelOrderProduct = await db.OrderProduct.Where(op=>op.Order.ClientId == id).ToListAsync();
            db.OrderProduct.RemoveRange(delRelOrderProduct);

            var delRelOrders = await db.Orders.Where(o => o.ClientId == id).ToListAsync();
            db.Orders.RemoveRange(delRelOrders);

            await db.SaveChangesAsync();

            return deleteClient;
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
