using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using prueba_base.Context;
using prueba_base.Models;
using prueba_base.Dtos;
using System.Net.Http;
using System.Text;

namespace prueba_base.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsientoDiarioDetallesController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private string _token;
        private readonly AppDbContext _context;

        public AsientoDiarioDetallesController(AppDbContext context)
        {
            _context = context;
        }


        // GET: api/AsientoDiarioDetalles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AsientoDiarioDetalle>>> GetAsientoDiarioDetalles()
        {
          var asientoDiarioDetalle =  await _context.AsientoDiarioDetalles.ToListAsync();

            

            var dtoList = asientoDiarioDetalle.Select(detalle => new AsientoDiarioCliente
            {
                CodigoPrincipal = detalle.id.ToString(),
                DFxRegistro = DateTime.Now,
                CDsObservacion = detalle.descripcion,
                CCiUsuario = detalle.id_asientoDiario.ToString(),
                DFxUsuario = DateTime.Now,
                CSnTipo = "G",
                CodigoAnulacion = null,
                CDsMotivoAnulacion = null,
                CCiCuentaContable = detalle.id_asientoDiario.ToString(),
                CCiCentroCosto = detalle.id_centroCosto.ToString(),
                CCiTipoPiscina = "por hacer",
                CNuPiscina = "por hacer",
                NNuDebe = detalle.debito,
                NNuHaber = detalle.credito,
                CDsDetalle = detalle.descripcion,
                CCeProceso = true,
                CNoError = null
            }).ToList();

            return Ok(dtoList);
        }

        // GET: api/AsientoDiarioDetalles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AsientoDiarioCliente>> GetAsientoDiarioDetalle(int id)
        {
            try
            {
                var asientoDiarioDetalle = await _context.AsientoDiarioDetalles.FindAsync(id);
            var comprobante = await _context.Comprobante.FirstOrDefaultAsync(c => c.numeroComprobante == asientoDiarioDetalle.referencia);
            var OrdenCompraDetalle = await _context.OrdenCompraDetalle.FirstOrDefaultAsync(o => o.id_orden == comprobante.id );

            if (asientoDiarioDetalle == null)
            {
                return NotFound();
            }
           
                var dto = new AsientoDiarioCliente
                {
                    CodigoPrincipal = asientoDiarioDetalle.referencia,
                    DFxRegistro = DateTime.Now,
                    CDsObservacion = asientoDiarioDetalle.descripcion,
                    CCiUsuario = "Incluirlo en el Controller de ERP",
                    DFxUsuario = DateTime.Now,
                    CSnTipo = "G",
                    CodigoAnulacion = null,
                    CDsMotivoAnulacion = null,
                    CCiCuentaContable = asientoDiarioDetalle.id_asientoDiario.ToString(),
                    CCiCentroCosto = asientoDiarioDetalle.id_centroCosto.ToString(),
                    CCiTipoPiscina = OrdenCompraDetalle.unidadProduccion,
                    CNuPiscina = OrdenCompraDetalle.unidadProduccion,
                    NNuDebe = asientoDiarioDetalle.debito,
                    NNuHaber = asientoDiarioDetalle.debito,
                    CDsDetalle = asientoDiarioDetalle.descripcion,
                    CCeProceso = true,
                    CNoError = null

                };

                return Ok(dto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Ha ocurrido un error en el servidor, no existe Orden de Compra con este Asiento  ", details = ex.Message });

            }

        }

        // PUT: api/AsientoDiarioDetalles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsientoDiarioDetalle(int id, AsientoDiarioDetalle asientoDiarioDetalle)
        {
            if (id != asientoDiarioDetalle.id)
            {
                return BadRequest();
            }

            _context.Entry(asientoDiarioDetalle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AsientoDiarioDetalleExists(id))
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

        // POST: api/AsientoDiarioDetalles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AsientoDiarioDetalle>> PostAsientoDiarioDetalle(AsientoDiarioDetalle asientoDiarioDetalle)
        {
            _context.AsientoDiarioDetalles.Add(asientoDiarioDetalle);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAsientoDiarioDetalle", new { id = asientoDiarioDetalle.id }, asientoDiarioDetalle);
        }

        // DELETE: api/AsientoDiarioDetalles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsientoDiarioDetalle(int id)
        {
            var asientoDiarioDetalle = await _context.AsientoDiarioDetalles.FindAsync(id);
            if (asientoDiarioDetalle == null)
            {
                return NotFound();
            }

            _context.AsientoDiarioDetalles.Remove(asientoDiarioDetalle);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AsientoDiarioDetalleExists(int id)
        {
            return _context.AsientoDiarioDetalles.Any(e => e.id == id);
        }
    }
}
