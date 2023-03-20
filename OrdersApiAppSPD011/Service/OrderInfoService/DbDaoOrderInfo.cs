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

            Order order = db.Orders.FindAsync(id).Result;
            Client client = db.Clients.FindAsync(order.ClientId).Result;
            List<OrderProduct> products = db.OrderProduct.Where(x => x.OrderId == id).ToList();

            orderInfo.Order = order;
            orderInfo.Client = client;
            orderInfo.Products = products;

            return orderInfo;

        }
    }
}
