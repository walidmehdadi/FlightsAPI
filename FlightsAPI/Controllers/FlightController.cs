using FlightsAPI.Data;
using FlightsAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlightsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController(FlightsDbContext context) : ControllerBase
    {
        private readonly FlightsDbContext _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Flight>>> GetFlights()
        {
            return await _context.Flights
                .ToListAsync();// Return all flights
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Flight>> GetFlight(int id)
        {
            // Find the flight by its ID
            var flight = await _context.Flights
                .SingleOrDefaultAsync(s => s.Id == id);

            if (flight == null)
            {
                return NotFound();
            }

            // Return flight details
            return Ok(flight);
        }

        [HttpPost]
        public async Task<ActionResult<Flight>> AddFlight(Flight flight)
        {
            _context.Flights.Add(flight);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFlight), new { id = flight.Id }, flight);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFlight(int id, Flight updatedFlight)
        {
            if (id != updatedFlight.Id)
            {
                return BadRequest();
            }

            _context.Entry(updatedFlight).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Flights.Any(s => s.Id == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFlight(int id)
        {
            var flight = await _context.Flights
                .SingleOrDefaultAsync(s => s.Id == id);

            if (flight == null)
            {
                return NotFound();
            }

            // Remove the flight from the database
            _context.Flights.Remove(flight);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
