﻿using System;
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
        [HttpGet("Reservations")]
        public async Task<IEnumerable<Reservation>> Get()
        {
            return await _reservationService.ReadAll();
        }

        // GET: api/Reservation
        [HttpGet]
        public async Task<ActionResult<Reservation>> Get([FromQuery] int id, [FromQuery] string name)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            Reservation reservation = await _reservationService.Read(id, name);
            if (reservation == null)
                return BadRequest("There's no reservation with such an id and last name");
            return Ok(reservation);
        }

        [HttpGet("Cars")]
        public async Task<List<Car>> GetCars()
        {
            return await _reservationService.ReadAllCars();
        }

        [HttpGet("AvailableCars")]
        public async Task<List<Car>> GetAvailableCars([FromQuery] DateTime pickUpDate, [FromQuery] DateTime returnDate, [FromQuery] int? id=null)
        {
            return await _reservationService.GetAvailableCars(pickUpDate, returnDate, id);
        }

        // POST: api/Reservation
        [HttpPost]
        public async Task<ActionResult<Reservation>> Post([FromBody] Reservation reservation)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                Reservation res = await _reservationService.Create(reservation);
                return CreatedAtAction(nameof(Get), res.Id, res);
            }
            catch (ArgumentException exception)
            {
                return BadRequest(exception.Message);
            }   
        }

        //PUT: api/Reservation/5
        [HttpPut]
        public async Task<ActionResult<Reservation>> Put([FromQuery] int id, [FromBody] Reservation reservation, [FromQuery] string name)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                Reservation res = await _reservationService.Update(id, reservation, name);
                return Ok(res);
            }
            catch (ArgumentNullException exception)
            {
                return BadRequest(exception.ParamName);
            }
            catch (ArgumentException exception)
            {
                return BadRequest(exception.Message);
            }

            
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id, [FromQuery] string name)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                await _reservationService.Delete(id, name);
            }
            catch (ArgumentNullException exception)
            {
                return BadRequest(exception.ParamName);
            }

            return Ok();
        }


    }
}
