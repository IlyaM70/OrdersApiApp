using Microsoft.AspNetCore.Mvc;
using OrdersApiAppSPD011.Model.Entity;
using OrdersApiAppSPD011.Service;

namespace OrdersApiAppSPD011.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IDao<Order> daoOrder;

        public OrderController(IDao<Order> daoOrder)
        {
            this.daoOrder = daoOrder;
        }



        // GET: /order/all
        [HttpGet("all")]
        public async Task<List<Order>> GetAll()
        {
            return await daoOrder.GetAllAsync();
        }

        // GET order/{id}
        [HttpGet("{id}")]
        public async Task<Order> Get(int id)
        {
            return await daoOrder.GetAsync(id);
        }

        // POST order/add
        [HttpPost("add")]
        public async Task<Order> Post([FromBody] Order order)
        {
            return await daoOrder.AddAsync(order);
        }

        // PUT order/update/{id}
        [HttpPut("update/{id}")]
        public async Task<Order> Put(int id, [FromBody] Order order)
        {
            order.Id = id;
            return await daoOrder.UpdateAsync(order);
        }

        // DELETE order/delete/{id}
        [HttpDelete("delete/{id}")]
        public async Task<Order> Delete(int id)
        {
            return await daoOrder.DeleteAsync(id);
        }
    }
}
