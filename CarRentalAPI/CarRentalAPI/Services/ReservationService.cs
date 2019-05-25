using CarRentalAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRentalAPI.Data.Model;

namespace CarRentalAPI.Services
{
    public class ReservationService
    {
        private CarDbContext _carDbContext;

        public ReservationService(CarDbContext carDbContext)
        {
            _carDbContext = carDbContext;
        }

        public int Create(Reservation reservation)
        {
            _carDbContext.Reservations.Add(reservation);
            _carDbContext.SaveChanges();
            return reservation.Id;
        }

        public List<Reservation> ReadAll()
        {
            return _carDbContext.Reservations.ToList();
        }

        public Reservation Read(int id)
        {
            return _carDbContext.Reservations.SingleOrDefault(reservation => reservation.Id == id);
        }

        public void Delete(int id)
        {
            Reservation reservation = Read(id);
            if (reservation == null)
                throw new ArgumentNullException("There's no reservation with such an id");
            _carDbContext.Reservations.Remove(reservation);
            _carDbContext.SaveChanges();
        }
    }
}
