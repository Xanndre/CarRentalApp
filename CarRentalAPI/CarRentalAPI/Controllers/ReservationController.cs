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
    public class ReservationController : ControllerBase
    {
        private ReservationService _reservationService;

        public ReservationController(ReservationService reservationService)
        {
            _reservationService = reservationService;
        }
        
        // GET: api/Reservation
        [HttpGet]
        public IEnumerable<Reservation> Get()
        {
            return _reservationService.ReadAll();
        }

        // GET: api/Reservation/5
        [HttpGet("{id}")]
        public ActionResult<Reservation> Get(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            Reservation reservation = _reservationService.Read(id);
            if (reservation == null)
                return BadRequest("There's no reservation with such an id");
            return Ok(reservation);
        }

        // POST: api/Reservation
        [HttpPost]
        public IActionResult Post([FromBody] Reservation reservation)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            int id = _reservationService.Create(reservation);
            return Created("api/Reservation", id);
        }

        // PUT: api/Reservation/5
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
                _reservationService.Delete(id);
            }
            catch (ArgumentNullException exception)
            {
                return BadRequest(exception.Message);
            }

            return Ok("Successfully deleted");
        }
    }
}
