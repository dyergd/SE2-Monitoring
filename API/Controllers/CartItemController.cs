using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MonitoringProj.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonitoringProj.Controllers
{
    /// <summary>
    /// Class for CartItem table in database
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemController : ControllerBase
    {
        //Represents connection to the database
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Constructor for CartItemController Class
        /// </summary>
        /// <param name="context"> Database Context </param>
        public CartItemController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// GET: api/cart_item
        /// </summary>
        /// <returns>JSON list of CartItems</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CartItem>>> GetCartItems()
        {
            return await _context.CartItems.ToListAsync();
        }

        /// <summary>
        /// GET: api/cart_item/5
        /// </summary>
        /// <param name="id">Id of cart_item</param>
        /// <returns>A particular cartitem</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<CartItem>> Getcart_item(int id)
        {
            var cart_item = await _context.CartItems.FindAsync(id);

            if (cart_item == null)
            {
                return NotFound();
            }

            return cart_item;
        }

        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// PUT: api/cart_item/5
        /// </summary>
        /// <param name="id">ID of cartitem to update</param>
        /// <param name="cart_item">Updated CartItem</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Putcart_item(int id, CartItem cart_item)
        {
            if (id != cart_item.Id)
            {
                return BadRequest();
            }

            _context.Entry(cart_item).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!cart_itemExists(id))
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
        /// POST: api/cart_item
        /// </summary>
        /// <param name="cart_item">New CartItem</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<CartItem>> Postcart_item(CartItem cart_item)
        {
            _context.CartItems.Add(cart_item);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getcart_item", new { id = cart_item.Id }, cart_item);
        }

        /// <summary>
        /// DELETE: api/cart_item/5
        /// </summary>
        /// <param name="id">CartItem ID</param>
        /// <returns>Not found if cartitem doesn't exist</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletecart_item(int id)
        {
            var cart_item = await _context.CartItems.FindAsync(id);
            if (cart_item == null)
            {
                return NotFound();
            }

            _context.CartItems.Remove(cart_item);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Checks to see if a particular CartItem exists.
        /// </summary>
        /// <param name="id">ID of Cart</param>
        /// <returns></returns>
        private bool cart_itemExists(int id)
        {
            return _context.CartItems.Any(e => e.Id == id);
        }
    }
}
