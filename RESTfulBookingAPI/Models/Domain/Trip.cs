using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace RESTfulBookingAPI.Models.Domain
{
    
    public class Trip
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CityName { get; set; }
        [DataType("decimal(18,2)")]
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
