using CarRentalAPI.Data;
using System;
using System.Collections.Generic;
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

        public async Task<int> Create(Reservation reservation)
        {
            await _carDbContext.Reservations.AddAsync(reservation);
            await _carDbContext.SaveChangesAsync();
            return reservation.Id;
        }

        public async Task<List<Reservation>> ReadAll()
        {
            return await _carDbContext.Reservations.ToListAsync();
        }

        public async Task<Reservation> Read(int id)
        {
            return await _carDbContext.Reservations.SingleOrDefaultAsync(reservation => reservation.Id == id);
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
            res.CarId = reservation.CarId;
            res.PickUpLocation = reservation.PickUpLocation;
            res.ReturnLocation = reservation.ReturnLocation;
            res.PickUpDate = reservation.PickUpDate;
            res.ReturnDate = reservation.ReturnDate;
            await _carDbContext.SaveChangesAsync();

        }

        public async Task<List<Car>> GetAvailableCars(DateTime pickUpDate, DateTime returnDate)
        {
            List<Car> unavailableCars = new List<Car>();
            foreach (Reservation reservation in _carDbContext.Reservations)
            {
                if(returnDate >= reservation.PickUpDate && pickUpDate <= reservation.ReturnDate)
                    unavailableCars.Add(reservation.Car);
            }
            return await _carDbContext.Cars.Except(unavailableCars).ToListAsync();
        }
    }
}
