using Microsoft.AspNetCore.Mvc;
using OrdersApiAppSPD011.Service.OrderInfoService;


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
        public async Task<object> Get(int id)
        {
            return await daoOrderInfo.GetAsync(id);
        }
    }
}
