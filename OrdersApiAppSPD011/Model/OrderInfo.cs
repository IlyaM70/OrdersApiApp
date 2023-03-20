using OrdersApiAppSPD011.Model.Entity;

namespace OrdersApiAppSPD011.Model
{
    public class OrderInfo
    {
        public Order Order { get; set; }
        public List<Product> Products { get; set; }
        public int Quantity { get; set; }

    }
}
