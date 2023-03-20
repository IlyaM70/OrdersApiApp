using OrdersApiAppSPD011.Model.Entity;

namespace OrdersApiAppSPD011.Model
{
    public class OrderInfo
    {
        public Client Client { get; set; }
        public Order Order { get; set; }
        public List<OrderProduct> Products { get; set; }

    }
}
