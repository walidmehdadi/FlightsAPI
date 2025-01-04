using FlightsAPI.Data;
using FlightsAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlightsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllianceController(FlightsDbContext context) : ControllerBase
    {
        private readonly FlightsDbContext _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Alliance>>> GetAlliances()
        {
            return await _context.Alliances
                .ToListAsync();// Return all alliance
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Alliance>> GetAlliance(int id)
        {
            // Find the alliance by its ID
            var alliance = await _context.Alliances
                .SingleOrDefaultAsync(s => s.Id == id);

            if (alliance == null)
            {
                return NotFound();
            }

            // Return alliance details
            return Ok(alliance);
        }

        [HttpPost]
        public async Task<ActionResult<Alliance>> AddAlliance(Alliance alliance)
        {
            _context.Alliances.Add(alliance);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAlliance), new { id = alliance.Id }, alliance);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAlliance(int id, Alliance updatedAlliance)
        {
            if (id != updatedAlliance.Id)
            {
                return BadRequest();
            }

            _context.Entry(updatedAlliance).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Alliances.Any(s => s.Id == id))
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
        public async Task<IActionResult> DeleteAlliance(int id)
        {
            var alliance = await _context.Alliances
                .SingleOrDefaultAsync(s => s.Id == id);

            if (alliance == null)
            {
                return NotFound();
            }

            // Remove the alliance from the database
            _context.Alliances.Remove(alliance);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
