using Microsoft.AspNetCore.Mvc;
using OrdersApiAppSPD011.Model;
using OrdersApiAppSPD011.Model.Entity;
using OrdersApiAppSPD011.Service;
using OrdersApiAppSPD011.Service.CheckService;
using OrdersApiAppSPD011.Service.OrderInfoService;
using OrdersApiAppSPD011.Service.OrderService;

namespace OrdersApiAppSPD011.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class CheckController : ControllerBase
    {
        private IDaoCheck daoCheck;

        public CheckController(IDaoCheck daoCheck)
        {
            this.daoCheck = daoCheck;
        }


        // GET check/{id}
        [HttpGet("{id}")]
        public async Task<object> Get(int id)
        {
            return await daoCheck.GetAsync(id);
        }
    }
}
