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
    public class CarController : ControllerBase
    {
        private CarService _carService;

        public CarController(CarService carService)
        {
            _carService = carService;
        }
        
        // GET: api/Car
        [HttpGet]
        public IEnumerable<Car> Get()
        {
            return _carService.ReadAll();
        }

        // GET: api/Car/5
        [HttpGet("{id}")]
        public ActionResult<Car> Get(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            Car car = _carService.Read(id);
            if (car == null)
                return BadRequest("There's no car with such an id");
            return Ok(car);
        }

        // POST: api/Car
        [HttpPost]
        public IActionResult Post([FromBody] Car car)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            int id = _carService.Create(car);
            return Created("api/Car", id);
        }

        // PUT: api/Car/5
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
                _carService.Delete(id);
            }
            catch(ArgumentNullException exception)
            {
                return BadRequest(exception.Message);
            }

            return Ok("Successfully deleted");
        }
    }
}
