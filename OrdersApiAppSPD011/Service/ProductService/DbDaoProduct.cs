using Microsoft.EntityFrameworkCore;
using OrdersApiAppSPD011.Model;
using OrdersApiAppSPD011.Model.Entity;

namespace OrdersApiAppSPD011.Service.ProductService
{
    public class DbDaoProduct : IDao<Product>
    {
        private AppDbContext db;

        public DbDaoProduct(AppDbContext db)
        {
            this.db = db;
        }

        public async Task<Product> AddAsync(Product product)
        {
            db.Products.Add(product);
            await db.SaveChangesAsync();
            return product;
        }

        public async Task<Product> DeleteAsync(int id)
        {
            var toDelete = await db.Products.FindAsync(id);
            if (toDelete != null)
            {
                db.Products.Remove(toDelete);
                await db.SaveChangesAsync();
                return toDelete;
            }
            else return null;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await db.Products.ToListAsync();
        }

        public async Task<Product> GetAsync(int id)
        {
            return await db.Products.FindAsync(id);
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            db.Products.Update(product);
            await db.SaveChangesAsync();
            return product;
        }
    }
}
