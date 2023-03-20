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

        public async Task<OrderInfo> GetAsync(int id)
        {
            OrderInfo orderInfo = new OrderInfo();

            Order order = await db.Orders.Include(c=>c.Client).FirstOrDefaultAsync(o=>o.Id == id);
            List<Product> products = await db.OrderProduct.Where(op => op.OrderId == id).Select(c=>c.Product).ToListAsync();
           
            orderInfo.Order = order;
            orderInfo.Products = products;

            return orderInfo;

        }
    }
}
