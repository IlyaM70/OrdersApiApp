using Microsoft.AspNetCore.Mvc;
using OrdersApiAppSPD011.Model.Entity;
using OrdersApiAppSPD011.Service;

namespace OrdersApiAppSPD011.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class OrderProductController : ControllerBase
    {
        private IDao<OrderProduct> daoOrderProduct;

        public OrderProductController(IDao<OrderProduct> daoOrderProduct)
        {
            this.daoOrderProduct = daoOrderProduct;
        }

        // GET: /orderproduct/all
        [HttpGet("all")]
        public async Task<List<OrderProduct>> GetAll()
        {
            return await daoOrderProduct.GetAllAsync();
        }

        // GET orderproduct/{id}
        [HttpGet("{id}")]
        public async Task<OrderProduct> Get(int id)
        {
            return await daoOrderProduct.GetAsync(id);
        }

        // POST orderproduct/add
        [HttpPost("add")]
        public async Task<OrderProduct> Post([FromBody] OrderProduct orderProduct)
        {
            return await daoOrderProduct.AddAsync(orderProduct);
        }

        // PUT orderproduct/update/{id}
        [HttpPut("update/{id}")]
        public async Task<OrderProduct> Put(int id, [FromBody] OrderProduct orderProduct)
        {
            orderProduct.Id = id;
            return await daoOrderProduct.UpdateAsync(orderProduct);
        }

        // DELETE orderproduct/delete/{id}
        [HttpDelete("delete/{id}")]
        public async Task<OrderProduct> Delete(int id)
        {
            return await daoOrderProduct.DeleteAsync(id);
        }
    }
}
