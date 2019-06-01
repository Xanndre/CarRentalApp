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
                    new Car{ Id = 1, Brand = "test1", Cost = 31, Description = "Simple description1", ImageUrl = "https://hdqwalls.com/download/audi-r8-1366x768.jpg" },
                    new Car{ Id = 2, Brand = "test2", Cost = 32, Description = "Simple description2", ImageUrl = "http://s1.1zoom.me/b5050/715/BMW_M5_Blue_Sedan_549904_1366x768.jpg" },
                    new Car{ Id = 3, Brand = "test3", Cost = 33, Description = "Simple description3", ImageUrl = "http://s1.1zoom.me/b5364/28/Renault_Trophy_2015_Renaultsport_Clio_White_525674_1366x768.jpg" }
                }
            );
        }
    }
}
