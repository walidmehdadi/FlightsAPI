using FlightsAPI.Data;
using FlightsAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlightsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirlineController(FlightsDbContext context) : ControllerBase
    {
        private readonly FlightsDbContext _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Airline>>> GetAirlines()
        {
            return await _context.Airlines
                .ToListAsync();// Return all airlines
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Airline>> GetAirline(int id)
        {
            // Find the airline by its ID
            var airline = await _context.Airlines
                .SingleOrDefaultAsync(s => s.Id == id);

            if (airline == null)
            {
                return NotFound();
            }

            // Return airline details
            return Ok(airline);
        }

        [HttpPost]
        public async Task<ActionResult<Airline>> AddAirline(Airline airline)
        {
            _context.Airlines.Add(airline);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAirline), new { id = airline.Id }, airline);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAirline(int id, Airline updatedAirline)
        {
            if (id != updatedAirline.Id)
            {
                return BadRequest();
            }

            _context.Entry(updatedAirline).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Airlines.Any(s => s.Id == id))
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
        public async Task<IActionResult> DeleteAirline(int id)
        {
            var airline = await _context.Airlines
                .SingleOrDefaultAsync(s => s.Id == id);

            if (airline == null)
            {
                return NotFound();
            }

            // Remove the airline from the database
            _context.Airlines.Remove(airline);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
