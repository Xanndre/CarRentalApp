using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRentalAPI.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace CarRentalAPI.Data
{
    public class CarDbContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        public CarDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().HasData(new[]{
                    new Car{ Id = 1, Brand = "test1", Cost = 31, Description = "Simple description1", ImageUrl = "Url1" },
                    new Car{ Id = 2, Brand = "test2", Cost = 32, Description = "Simple description2", ImageUrl = "Url2" },
                    new Car{ Id = 3, Brand = "test3", Cost = 33, Description = "Simple description3", ImageUrl = "Url3" }
                }
            );
        }
    }
}
