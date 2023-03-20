using Microsoft.EntityFrameworkCore;
using OrdersApiAppSPD011.Model;
using OrdersApiAppSPD011.Model.Entity;

namespace OrdersApiAppSPD011.Service.OrderProductService
{
    public class DbDaoOrderProduct : IDao<OrderProduct>
    {
        private AppDbContext db;

        public DbDaoOrderProduct(AppDbContext db)
        {
            this.db = db;
        }

        public async Task<OrderProduct> AddAsync(OrderProduct orderProduct)
        {
            db.OrderProduct.Add(orderProduct);
            await db.SaveChangesAsync();
            return orderProduct;
        }

        public async Task<OrderProduct> DeleteAsync(int id)
        {
            var toDelete = await db.OrderProduct.FindAsync(id);
            if (toDelete != null)
            {
                db.OrderProduct.Remove(toDelete);
                await db.SaveChangesAsync();
                return toDelete;
            }
            else return null;
        }

        public async Task<List<OrderProduct>> GetAllAsync()
        {
            return await db.OrderProduct.ToListAsync();
        }

        public async Task<OrderProduct> GetAsync(int id)
        {
            return await db.OrderProduct.FindAsync(id);
        }

        public async Task<OrderProduct> UpdateAsync(OrderProduct orderProduct)
        {
            db.OrderProduct.Update(orderProduct);
            await db.SaveChangesAsync();
            return orderProduct;
        }
    }
}
