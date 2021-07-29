using System;

namespace RESTfulBookingAPI.Models.Domain
{
    public class Reservation
    {
        public int Id { get; set; }
        public string ReservedBy { get; set; }
        public string CustomerName { get; set; }
        public DateTime ReservationDate { get; set; }
        public DateTime CreationDate { get; set; }
        public string Notes { get; set; }
        public string TripName { get; set; }
    }
}
