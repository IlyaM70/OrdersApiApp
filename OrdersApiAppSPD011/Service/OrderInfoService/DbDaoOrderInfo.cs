using Microsoft.EntityFrameworkCore;
using OrdersApiAppSPD011.Model;
using OrdersApiAppSPD011.Model.Entity;

namespace OrdersApiAppSPD011.Service.OrderInfoService
{
    public class DbDaoOrderInfo : IDaoOrderInfo
    {
        private AppDbContext db;

        public DbDaoOrderInfo(AppDbContext db)
        {
            this.db = db;
        }

        public async Task<object> GetAsync(int id)
        {
            Order order = await db.Orders.Include(c=>c.Client).FirstOrDefaultAsync(o=>o.Id == id);
            var products = await db.OrderProduct.Where(op => op.OrderId == id)
                .Select(op => new {op.Product,op.Quantity})
                .ToListAsync();

            var OrderInfo = new
            {
                Order = order,
                Products = products
            };
            
            return OrderInfo;

        }
    }
}
