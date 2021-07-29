using System.ComponentModel.DataAnnotations;

namespace RESTfulBookingAPI.Models.Domain
{
    public class User
    {
        public int Id { get; set; }
        [MaxLength(350)]
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
