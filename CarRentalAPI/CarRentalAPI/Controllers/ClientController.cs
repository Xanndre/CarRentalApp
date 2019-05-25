using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRentalAPI.Data.Model;
using CarRentalAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private ClientService _clientService;

        public ClientController(ClientService clientService)
        {
            _clientService = clientService;
        }

        // GET: api/Client
        [HttpGet]
        public IEnumerable<Client> Get()
        {
            return _clientService.ReadAll();
        }

        // GET: api/Client/5
        [HttpGet("{id}")]
        public ActionResult<Client> Get(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            Client client = _clientService.Read(id);
            if (client == null)
                return BadRequest("There's no client with such an id");
            return Ok(client);
        }

        // POST: api/Client
        [HttpPost]
        public IActionResult Post([FromBody] Client client)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            int id = _clientService.Create(client);
            return Created("api/Client", id);
        }

        // PUT: api/Client/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                _clientService.Delete(id);
            }
            catch(ArgumentNullException exception)
            {
                return BadRequest(exception.Message);
            }

            return Ok("Successfully deleted");
        }
    }
}
