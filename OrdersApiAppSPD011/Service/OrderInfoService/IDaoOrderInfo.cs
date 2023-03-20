using OrdersApiAppSPD011.Model;

namespace OrdersApiAppSPD011.Service.OrderInfoService
{
    public interface IDaoOrderInfo
    {
        Task<OrderInfo> GetAsync(int id);
    }
}
