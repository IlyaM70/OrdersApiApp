using Microsoft.EntityFrameworkCore;
using OrdersApiAppSPD011.Model;

namespace OrdersApiAppSPD011.Service.CheckService
{
    public class DbDaoCheck : IDaoCheck
    {
        private AppDbContext db;

        public DbDaoCheck(AppDbContext db)
        {
            this.db = db;
        }

        public async Task<object> GetAsync(int id)
        {
            var products = await db.OrderProduct.Where(op => op.OrderId == id)
                .Select(op => new { op.Product.Name,op.Product.Price, op.Quantity })
                .ToListAsync();

            double summ = 0;
            double price = 0;

            foreach (var product in products) {
                price = product.Price*product.Quantity;
                summ+= price;
                price = 0;
            }
            var check = new
            {
                Products = products,
                Summary = summ
            };
            return check;
        }
    }
}
