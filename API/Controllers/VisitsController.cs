using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MonitoringProj.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonitoringProj.Controllers
{
    /// <summary>
    /// Class for Visit Controller
    /// Expects and returns JSON
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class VisitsController : ControllerBase
    {
        //Represents connection to the database
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Controller for VisisController
        /// </summary>
        /// <param name="context">Database Context</param>
        public VisitsController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// GET: api/visits
        /// </summary>
        /// <returns>A JSON list of visit table in database.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Visit>>> Getvisits()
        {
            return await _context.visits.ToListAsync();
        }

        /// <summary>
        /// Get a particular Visit
        /// GET: api/visits/5
        /// </summary>
        /// <param name="id">id of visit</param>
        /// <returns>A particular visit with specific id or not found if object is not found</returns>
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

        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Update a particular visit row in database
        /// PUT: api/visits/5
        /// </summary>
        /// <param name="id">ID of Visit</param>
        /// <param name="visit">Updated Visit</param>
        /// <returns></returns>
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

        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Post a new visit to database
        /// POST: api/visits
        /// </summary>
        /// <param name="visit">New Visit</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Visit>> Postvisit(Visit visit)
        {
            _context.visits.Add(visit);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getvisit", new { id = visit.Id }, visit);
        }

        /// <summary>
        /// Deletes a particular visit in vist table within database
        /// DELETE: api/visits/5
        /// </summary>
        /// <param name="id">ID of visit</param>
        /// <returns></returns>
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

        /// <summary>
        /// Check if a particular visit row in visit table exists 
        /// </summary>
        /// <param name="id">ID of visit</param>
        /// <returns>If the particular visit exists or not</returns>
        private bool visitExists(int id)
        {
            return _context.visits.Any(e => e.Id == id);
        }
    }
}
