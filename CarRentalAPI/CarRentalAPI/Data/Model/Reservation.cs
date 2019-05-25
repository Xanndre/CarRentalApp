using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentalAPI.Data.Model
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }
        public string PickUpLocation { get; set; }
        public string ReturnLocation { get; set; }
        public DateTime PickUpDate { get; set; }
        public DateTime ReturnDate { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }

        public int CarId { get; set; }
        public Car Car { get; set; }
    }
}
