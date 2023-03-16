using Microsoft.AspNetCore.Mvc;
using OrdersApiAppSPD011.Model.Entity;
using OrdersApiAppSPD011.Service;

namespace OrdersApiAppSPD011.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class ClientController: ControllerBase
    {
        private IDao<Client> dao;

        public ClientController(IDao<Client> dao)
        {
            this.dao = dao;
        }



        // GET: /client/all
        [HttpGet("all")]
        public async Task<List<Client>> GetAll()
        {
            return await dao.GetAllAsync();
        }

        // GET client/{id}
        [HttpGet("{id}")]
        public async Task<Client> Get(int id)
        {
            return await dao.GetAsync(id);
        }

        // POST client/add
        [HttpPost("add")]
        public async Task<Client> Post([FromBody] Client client)
        {
            return await dao.AddAsync(client);
        }

        // PUT client/update/{id}
        [HttpPut("update/{id}")]
        public async Task<Client> Put(int id, [FromBody] Client client)
        {
            client.Id = id;
            return await dao.UpdateAsync(client);
        }

        // DELETE client/delete/{id}
        [HttpDelete("delete/{id}")]
        public async Task<Client> Delete(int id)
        {
            return await dao.DeleteAsync(id);
        }
    }
}
