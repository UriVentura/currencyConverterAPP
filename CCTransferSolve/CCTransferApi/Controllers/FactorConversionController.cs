using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CCTransferApi.DbContexts;
using CCTransferApi.Models;

namespace CCTransferWeb.Controllers
{
    [Route("api/factorconversion")]
    [ApiController]
    public class FactorConversionController : ControllerBase
    {
        private readonly CCTransferDbContext _context;

        public FactorConversionController(CCTransferDbContext context)
        {
            _context = context;
        }

        // GET: api/FactorConversions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FactorConversion>>> GetFactorConversiones()
        {
            return await _context.FactorConversiones.ToListAsync();
        }

        // GET: api/FactorConversions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FactorConversion>> GetFactorConversion(int id)
        {
            var factorConversion = await _context.FactorConversiones.FindAsync(id);

            if (factorConversion == null)
            {
                return NotFound();
            }

            return factorConversion;
        }

        // PUT: api/FactorConversions/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFactorConversion(int id, FactorConversion factorConversion)
        {
            if (id != factorConversion.Id)
            {
                return BadRequest();
            }

            _context.Entry(factorConversion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FactorConversionExists(id))
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

        // POST: api/FactorConversions
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<FactorConversion>> PostFactorConversion(FactorConversion factorConversion)
        {
            _context.FactorConversiones.Add(factorConversion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFactorConversion", new { id = factorConversion.Id }, factorConversion);
        }

        // DELETE: api/FactorConversions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FactorConversion>> DeleteFactorConversion(int id)
        {
            var factorConversion = await _context.FactorConversiones.FindAsync(id);
            if (factorConversion == null)
            {
                return NotFound();
            }

            _context.FactorConversiones.Remove(factorConversion);
            await _context.SaveChangesAsync();

            return factorConversion;
        }

        private bool FactorConversionExists(int id)
        {
            return _context.FactorConversiones.Any(e => e.Id == id);
        }
    }
}
