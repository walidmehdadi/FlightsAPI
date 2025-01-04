using System.ComponentModel.DataAnnotations;

namespace FlightsAPI.Models
{
    public class Alliance
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Continent { get; set; } = string.Empty;
        public List<Airline> Airlines = [];
    }
}
