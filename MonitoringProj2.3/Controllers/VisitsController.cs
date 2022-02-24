using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MonitoringProj2._3.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonitoringProj2._3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public VisitsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/visits
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Visit>>> Getvisits()
        {
            return await _context.visits.ToListAsync();
        }

        // GET: api/visits/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Visit>> Getvisit(int id)
        {
            var visit = await _context.visits.FindAsync(id);

            if (visit == null)
            {
                return NotFound();
            }

            return visit;
        }

        // PUT: api/visits/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putvisit(int id, Visit visit)
        {
            if (id != visit.Id)
            {
                return BadRequest();
            }

            _context.Entry(visit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!visitExists(id))
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

        // POST: api/visits
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Visit>> Postvisit(Visit visit)
        {
            _context.visits.Add(visit);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getvisit", new { id = visit.Id }, visit);
        }

        // DELETE: api/visits/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletevisit(int id)
        {
            var visit = await _context.visits.FindAsync(id);
            if (visit == null)
            {
                return NotFound();
            }

            _context.visits.Remove(visit);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool visitExists(int id)
        {
            return _context.visits.Any(e => e.Id == id);
        }
    }
}
