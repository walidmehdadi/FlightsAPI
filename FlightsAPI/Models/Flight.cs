using System.ComponentModel.DataAnnotations;

namespace FlightsAPI.Models
{
    public class Flight
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [RegularExpression(@"^\d{1,4}$", ErrorMessage = "FlightNumber must be a number with 1 to 4 digits.")]
        public int FlightNumber { get; set; }
        [Required]
        public string DepartureCity { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.Date)]
        [CustomValidation(typeof(Flight), nameof(ValidateCreatedDate))]
        public DateTime DepartureTime { get; set; }
        [Required]
        public string ArrivalCity { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.Date)]
        [CustomValidation(typeof(Flight), nameof(ValidateCreatedDate))]
        public DateTime ArrivalTime { get; set; }
        public int AirlineId { get; set; }
        public Airline Airline;

        // Custom validation for DepartureTime and ArrivalTime
        public static ValidationResult? ValidateCreatedDate(DateTime createdDate)
        {
            if (createdDate.Date < DateTime.Now.Date)
            {
                return new ValidationResult("The created date cannot be in the past.");
            }
            return ValidationResult.Success;
        }
    }
}
