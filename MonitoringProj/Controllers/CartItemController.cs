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
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CartItemController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/cart_item
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CartItem>>> GetCartItems()
        {
            return await _context.CartItems.ToListAsync();
        }

        // GET: api/cart_item/5
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

        // PUT: api/cart_item/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
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

        // POST: api/cart_item
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CartItem>> Postcart_item(CartItem cart_item)
        {
            _context.CartItems.Add(cart_item);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getcart_item", new { id = cart_item.Id }, cart_item);
        }

        // DELETE: api/cart_item/5
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

        private bool cart_itemExists(int id)
        {
            return _context.CartItems.Any(e => e.Id == id);
        }
    }
}
