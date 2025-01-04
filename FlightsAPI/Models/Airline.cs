using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;

namespace FlightsAPI.Models
{
    public class Airline
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "The airline code must be 2 characters long.")]
        public string AirlineCode { get; set; } = string.Empty;
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Country { get; set; } = string.Empty;
        public List<Flight> Flights = [];
        public int AllianceId { get; set; }
        public Alliance Alliance;
    }
}
