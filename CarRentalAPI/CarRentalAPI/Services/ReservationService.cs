﻿using CarRentalAPI.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CarRentalAPI.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace CarRentalAPI.Services
{
    public class ReservationService
    {
        private CarDbContext _carDbContext;

        public ReservationService(CarDbContext carDbContext)
        {
            _carDbContext = carDbContext;
        }

        public async Task<Reservation> Create(Reservation reservation)
        {
            if ((await GetAvailableCars(reservation.PickUpDate, reservation.ReturnDate)).All(car => car.Id != reservation.CarId))
                throw new ArgumentException("This car isn't available at this time");
            await _carDbContext.Reservations.AddAsync(reservation);
            await _carDbContext.SaveChangesAsync();
            return reservation;
        }

        public async Task<List<Reservation>> ReadAll()
        {
            return await _carDbContext.Reservations.Include(r=>r.Car).ToListAsync();
        }

        public async Task<Reservation> Read(int id)
        {
            return await _carDbContext.Reservations.Include(r=>r.Car).SingleOrDefaultAsync(reservation => reservation.Id == id);
        }

        public async Task Delete(int id)
        {
            Reservation reservation = await Read(id);
            if (reservation == null)
                throw new ArgumentNullException("There's no reservation with such an id");
            _carDbContext.Reservations.Remove(reservation);
            await _carDbContext.SaveChangesAsync();
        }

        public async Task Update(int id, Reservation reservation)
        {
            Reservation res = await Read(id);
            if (res == null)
                throw new ArgumentNullException("There's no reservation with such an id");

            if ((await GetAvailableCars(reservation.PickUpDate, reservation.ReturnDate, id)).All(car => car.Id != reservation.CarId))
                throw new ArgumentException("This car isn't available at this time");
           
            res.PickUpLocation = reservation.PickUpLocation;
            res.ReturnLocation = reservation.ReturnLocation;
            res.PickUpDate = reservation.PickUpDate;
            res.ReturnDate = reservation.ReturnDate;
            await _carDbContext.SaveChangesAsync();

        }

        public async Task<List<Car>> GetAvailableCars(DateTime pickUpDate, DateTime returnDate, int? id=null)
        {
            List<Car> unavailableCars = new List<Car>();
            foreach (Reservation reservation in _carDbContext.Reservations.Include(c=> c.Car))
            {
                if(returnDate >= reservation.PickUpDate && pickUpDate <= reservation.ReturnDate && reservation.Id!=id)
                   unavailableCars.Add(reservation.Car);
            }
            return await _carDbContext.Cars.Except(unavailableCars).ToListAsync();
        }

        public async Task<List<Car>> ReadAllCars()
        {
            return await _carDbContext.Cars.ToListAsync();
        }
    }
}
