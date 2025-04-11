using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using prueba_base.Context;
using prueba_base.Models;

namespace prueba_base.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenCompraDetallesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OrdenCompraDetallesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/OrdenCompraDetalles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrdenCompraDetalle>>> GetOrdenCompraDetalle()
        {
            return await _context.OrdenCompraDetalle.ToListAsync();
        }

        // GET: api/OrdenCompraDetalles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrdenCompraDetalle>> GetOrdenCompraDetalle(int id)
        {
            var ordenCompraDetalle = await _context.OrdenCompraDetalle.FindAsync(id);

            if (ordenCompraDetalle == null)
            {
                return NotFound();
            }

            return ordenCompraDetalle;
        }

        // PUT: api/OrdenCompraDetalles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrdenCompraDetalle(int id, OrdenCompraDetalle ordenCompraDetalle)
        {
            if (id != ordenCompraDetalle.id)
            {
                return BadRequest();
            }

            _context.Entry(ordenCompraDetalle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrdenCompraDetalleExists(id))
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

        // POST: api/OrdenCompraDetalles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrdenCompraDetalle>> PostOrdenCompraDetalle(OrdenCompraDetalle ordenCompraDetalle)
        {
            _context.OrdenCompraDetalle.Add(ordenCompraDetalle);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrdenCompraDetalle", new { id = ordenCompraDetalle.id }, ordenCompraDetalle);
        }

        // DELETE: api/OrdenCompraDetalles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrdenCompraDetalle(int id)
        {
            var ordenCompraDetalle = await _context.OrdenCompraDetalle.FindAsync(id);
            if (ordenCompraDetalle == null)
            {
                return NotFound();
            }

            _context.OrdenCompraDetalle.Remove(ordenCompraDetalle);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrdenCompraDetalleExists(int id)
        {
            return _context.OrdenCompraDetalle.Any(e => e.id == id);
        }
    }
}
