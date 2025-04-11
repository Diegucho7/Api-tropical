﻿using System;
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
    public class ComprobantesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ComprobantesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Comprobantes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Comprobante>>> GetComprobante()
        {
            return await _context.Comprobante.ToListAsync();
        }

        // GET: api/Comprobantes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Comprobante>> GetComprobante(int id)
        {
            var comprobante = await _context.Comprobante.FindAsync(id);
           

            if (comprobante == null)
            {
                return NotFound();
            }

            return comprobante;
        }

        // PUT: api/Comprobantes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComprobante(int id, Comprobante comprobante)
        {
            if (id != comprobante.id)
            {
                return BadRequest();
            }

            _context.Entry(comprobante).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComprobanteExists(id))
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

        // POST: api/Comprobantes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Comprobante>> PostComprobante(Comprobante comprobante)
        {
            _context.Comprobante.Add(comprobante);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetComprobante", new { id = comprobante.id }, comprobante);
        }

        // DELETE: api/Comprobantes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComprobante(int id)
        {
            var comprobante = await _context.Comprobante.FindAsync(id);
            if (comprobante == null)
            {
                return NotFound();
            }

            _context.Comprobante.Remove(comprobante);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ComprobanteExists(int id)
        {
            return _context.Comprobante.Any(e => e.id == id);
        }
    }
}
