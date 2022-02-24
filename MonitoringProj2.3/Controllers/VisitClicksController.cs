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
    public class VisitClicksController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public VisitClicksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/visit_clicks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VisitClicks>>> GetVisitClicks()
        {
            return await _context.VisitClicks.ToListAsync();
        }

        // GET: api/visit_clicks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VisitClicks>> Getvisit_clicks(int id)
        {
            var visit_clicks = await _context.VisitClicks.FindAsync(id);

            if (visit_clicks == null)
            {
                return NotFound();
            }

            return visit_clicks;
        }

        // PUT: api/visit_clicks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putvisit_clicks(int id, VisitClicks visit_clicks)
        {
            if (id != visit_clicks.Id)
            {
                return BadRequest();
            }

            _context.Entry(visit_clicks).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!visit_clicksExists(id))
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

        // POST: api/visit_clicks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<VisitClicks>> Postvisit_clicks(VisitClicks visit_clicks)
        {
            _context.VisitClicks.Add(visit_clicks);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getvisit_clicks", new { id = visit_clicks.Id }, visit_clicks);
        }

        // DELETE: api/visit_clicks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletevisit_clicks(int id)
        {
            var visit_clicks = await _context.VisitClicks.FindAsync(id);
            if (visit_clicks == null)
            {
                return NotFound();
            }

            _context.VisitClicks.Remove(visit_clicks);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool visit_clicksExists(int id)
        {
            return _context.VisitClicks.Any(e => e.Id == id);
        }
    }
}
