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
        public async Task<IEnumerable<Reservation>> Get()
        {
            return await _reservationService.ReadAll();
        }

        // GET: api/Reservation/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Reservation>> Get(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            Reservation reservation = await _reservationService.Read(id);
            if (reservation == null)
                return BadRequest("There's no reservation with such an id");
            return Ok(reservation);
        }

        [HttpGet("Cars")]
        public async Task<List<Car>> GetCars()
        {
            return await _reservationService.ReadAllCars();
        }

        [HttpGet("AvailableCars")]
        public async Task<List<Car>> GetAvailableCars([FromQuery] DateTime pickUpDate, [FromQuery] DateTime returnDate)
        {
            return await _reservationService.GetAvailableCars(pickUpDate, returnDate);
        }

        // POST: api/Reservation
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Reservation reservation)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                int id = await _reservationService.Create(reservation);
                return Created("api/Reservation", id);
            }
            catch (ArgumentException exception)
            {
                return BadRequest(exception.Message);
            }   
        }

        //PUT: api/Reservation/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Reservation reservation)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                await _reservationService.Update(id, reservation);
            }
            catch (ArgumentNullException exception)
            {
                return BadRequest(exception.ParamName);
            }
            catch (ArgumentException exception)
            {
                return BadRequest(exception.Message);
            }

            return Ok("Successfully updated");
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                await _reservationService.Delete(id);
            }
            catch (ArgumentNullException exception)
            {
                return BadRequest(exception.ParamName);
            }

            return Ok("Successfully deleted");
        }
    }
}
