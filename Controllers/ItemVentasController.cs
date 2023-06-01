using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VentaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsVentaController : ControllerBase
    {
        private readonly VentaDbContext _context;

        public ItemsVentaController(VentaDbContext context)
        {
            _context = context;
        }

        // GET: api/ItemsVenta
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemVenta>>> GetItemsVenta()
        {
            return await _context.ItemVentas.ToListAsync();
        }

        // GET: api/ItemsVenta/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemVenta>> GetItemVenta(int id)
        {
            var itemVenta = await _context.ItemVentas.FindAsync(id);

            if (itemVenta == null)
            {
                return NotFound();
            }

            return itemVenta;
        }

        // PUT: api/ItemsVenta/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItemVenta(int id, ItemVenta itemVenta)
        {
            if (id != itemVenta.Id)
            {
                return BadRequest();
            }

            _context.Entry(itemVenta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemVentaExists(id))
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

            // POST: api/ItemsVenta
            [HttpPost]
            public async Task<ActionResult<ItemVenta>> PostItemVenta(ItemVenta itemVenta)
            {
                _context.ItemVentas.Add(itemVenta);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetItemVenta", new { id = itemVenta.Id }, itemVenta);
            }

            // DELETE: api/ItemsVenta/5
            [HttpDelete("{id}")]
            public async Task<ActionResult<ItemVenta>> DeleteItemVenta(int id)
            {
                var itemVenta = await _context.ItemVentas.FindAsync(id);
                if (itemVenta == null)
                {
                    return NotFound();
                }

                _context.ItemVentas.Remove(itemVenta);
                await _context.SaveChangesAsync();

                return itemVenta;
            }

            private bool ItemVentaExists(int id)
            {
                return _context.ItemVentas.Any(e => e.Id == id);
            }
        }

    }
