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
    /// API Controller for Cart table in database
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        //Represents connection to the database
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Constructor for CartController Class
        /// </summary>
        /// <param name="context"> Database Context </param>
        public CartController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// GET: api/carts
        /// </summary>
        /// <returns>JSON list of Carts</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cart>>> GetCarts()
        {
            return await _context.Carts.ToListAsync();
        }

        /// <summary>
        /// GET: api/carts/
        /// </summary>
        /// <param name="id">ID in the database</param>
        /// <returns>A single cart in JSON</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Cart>> Getcart(int id)
        {
            var cart = await _context.Carts.FindAsync(id);

            if (cart == null)
            {
                return NotFound();
            }

            return cart;
        }

        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Update a singular cart
        /// PUT: api/carts/5
        /// </summary>
        /// <param name="id">Id of the cart row to change</param>
        /// <param name="cart">Updated Cart</param>
        /// <returns>Not found if cart doesn't exist</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Putcart(int id, Cart cart)
        {
            if (id != cart.Id)
            {
                return BadRequest();
            }

            _context.Entry(cart).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!cartExists(id))
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
        /// Post a new cart to database
        /// POST: api/carts
        /// </summary>
        /// <param name="cart">A cart object</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Cart>> Postcart(Cart cart)
        {
            _context.Carts.Add(cart);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getcart", new { id = cart.Id }, cart);
        }

        // DELETE: api/carts/5
        /// <summary>
        /// Delete a cart at with a particular ID
        /// </summary>
        /// <param name="id">ID of Cart</param>
        /// <returns>Not found if the id doesn't exist</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletecart(int id)
        {
            var cart = await _context.Carts.FindAsync(id);
            if (cart == null)
            {
                return NotFound();
            }

            _context.Carts.Remove(cart);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Method for checking if a particular cart exists
        /// </summary>
        /// <param name="id">Cart ID</param>
        /// <returns></returns>
        private bool cartExists(int id)
        {
            return _context.Carts.Any(e => e.Id == id);
        }
    }
}
