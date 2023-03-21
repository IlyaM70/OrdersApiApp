using OrdersApiAppSPD011.Model;

namespace OrdersApiAppSPD011.Service.OrderInfoService
{
    public interface IDaoOrderInfo
    {
        Task<object> GetAsync(int id);
    }
}
