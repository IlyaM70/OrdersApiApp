using Microsoft.AspNetCore.Mvc;
using OrdersApiAppSPD011.Model.Entity;
using OrdersApiAppSPD011.Service;

namespace OrdersApiAppSPD011.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController: ControllerBase
    {
        private IDao<Product> dao;

        public ProductController(IDao<Product> dao)
        {
            this.dao = dao;
        }



        // GET: /product/all
        [HttpGet("all")]
        public async Task<List<Product>> GetAll()
        {
            return await dao.GetAllAsync();
        }

        // GET product/{id}
        [HttpGet("{id}")]
        public async Task<Product> Get(int id)
        {
            return await dao.GetAsync(id);
        }

        // POST product/add
        [HttpPost("add")]
        public async Task<Product> Post([FromBody] Product product)
        {
            return await dao.AddAsync(product);
        }

        // PUT product/update/{id}
        [HttpPut("update/{id}")]
        public async Task<Product> Put(int id, [FromBody] Product product)
        {
            product.Id = id;
            return await dao.UpdateAsync(product);
        }

        // DELETE product/delete/{id}
        [HttpDelete("delete/{id}")]
        public async Task<Product> Delete(int id)
        {
            return await dao.DeleteAsync(id);
        }
    }
}
