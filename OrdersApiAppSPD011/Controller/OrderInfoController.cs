using Microsoft.AspNetCore.Mvc;
using OrdersApiAppSPD011.Model;
using OrdersApiAppSPD011.Model.Entity;
using OrdersApiAppSPD011.Service;
using OrdersApiAppSPD011.Service.OrderInfoService;
using OrdersApiAppSPD011.Service.OrderService;

namespace OrdersApiAppSPD011.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class OrderInfoController : ControllerBase
    {
        private IDaoOrderInfo daoOrderInfo;

        public OrderInfoController(IDaoOrderInfo daoOrderInfo)
        {
            this.daoOrderInfo = daoOrderInfo;
        }

        // GET orderinfo/{id}
        [HttpGet("{id}")]
        public async Task<OrderInfo> Get(int id)
        {
            return await daoOrderInfo.GetAsync(id);
        }
    }
}
