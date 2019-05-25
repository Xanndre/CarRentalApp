using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mime;
using System.Security.Policy;
using System.Threading.Tasks;

namespace CarRentalAPI.Data.Model
{
    public class Car
    {
        [Key]
        public int Id { get; set; }
        public string Brand { get; set; }
        public double Cost { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
