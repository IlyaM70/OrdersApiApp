using Microsoft.EntityFrameworkCore;
using OrdersApiAppSPD011.Model;
using OrdersApiAppSPD011.Model.Entity;

namespace OrdersApiAppSPD011.Service.OrderService
{
    public class DbDaoOrder: IDao<Order>
    {
        private AppDbContext db;

        public DbDaoOrder(AppDbContext db)
        {
            this.db = db;
        }

        public async Task<Order> AddAsync(Order order)
        {
            db.Orders.Add(order);
            await db.SaveChangesAsync();
            return order;
        }

        public async Task<Order> DeleteAsync(int id)
        {
            var toDelete = await db.Orders.FindAsync(id);
            if (toDelete != null)
            {
                db.Orders.Remove(toDelete);
                await db.SaveChangesAsync();
                return toDelete;
            }
            else return null;
        }

        public async Task<List<Order>> GetAllAsync()
        {
            return await db.Orders.ToListAsync();
        }

        public async Task<Order> GetAsync(int id)
        {
            return await db.Orders.FindAsync(id);
        }

        public async Task<Order> UpdateAsync(Order order)
        {
            db.Orders.Update(order);
            await db.SaveChangesAsync();
            return order;
        }
    }
}
