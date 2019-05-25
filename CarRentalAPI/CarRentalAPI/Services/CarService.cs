using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CarRentalAPI.Data;
using CarRentalAPI.Data.Model;

namespace CarRentalAPI.Services
{
    public class CarService
    {
        private CarDbContext _carDbContext;

        public CarService(CarDbContext carDbContext)
        {
            _carDbContext = carDbContext;
        }

        public int Create(Car car)
        {
            _carDbContext.Cars.Add(car);
            _carDbContext.SaveChanges();
            return car.Id;
        }

        public List<Car> ReadAll()
        {
            return _carDbContext.Cars.ToList();
        }

        public Car Read(int id)
        {
            return _carDbContext.Cars.SingleOrDefault(car=>car.Id==id);
        }

        public void Delete(int id)
        {
            Car car = Read(id);
            if (car == null)
                throw new ArgumentNullException("There's no car with such an id");
            _carDbContext.Cars.Remove(car);
            _carDbContext.SaveChanges();
        }
    }
}
