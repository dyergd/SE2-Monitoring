using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MonitoringProj.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonitoringProj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitResponseController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public VisitResponseController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/visit_response
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VisitResponse>>> GetVisitResponses()
        {
            return await _context.VisitResponses.ToListAsync();
        }

        // GET: api/visit_response/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VisitResponse>> Getvisit_response(int id)
        {
            var visit_response = await _context.VisitResponses.FindAsync(id);

            if (visit_response == null)
            {
                return NotFound();
            }

            return visit_response;
        }

        // PUT: api/visit_response/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putvisit_response(int id, VisitResponse visit_response)
        {
            if (id != visit_response.Id)
            {
                return BadRequest();
            }

            _context.Entry(visit_response).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!visit_responseExists(id))
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

        // POST: api/visit_response
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<VisitResponse>> Postvisit_response(VisitResponse visit_response)
        {
            _context.VisitResponses.Add(visit_response);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getvisit_response", new { id = visit_response.Id }, visit_response);
        }

        // DELETE: api/visit_response/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletevisit_response(int id)
        {
            var visit_response = await _context.VisitResponses.FindAsync(id);
            if (visit_response == null)
            {
                return NotFound();
            }

            _context.VisitResponses.Remove(visit_response);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool visit_responseExists(int id)
        {
            return _context.VisitResponses.Any(e => e.Id == id);
        }
    }
}
