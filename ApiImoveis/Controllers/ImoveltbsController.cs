using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiImoveis.Data;
using ApiImoveis.Models;

namespace ApiImoveis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImoveltbsController : ControllerBase
    {
        private readonly ImovelContext _context;

        public ImoveltbsController(ImovelContext context)
        {
            _context = context;
        }

        // GET: api/Imoveltbs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Imoveltb>>> GetImoveltbs()
        {
            return await _context.Imoveltbs.ToListAsync();
        }

        // GET: api/Imoveltbs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Imoveltb>> GetImoveltb(int id)
        {
            var imoveltb = await _context.Imoveltbs.FindAsync(id);

            if (imoveltb == null)
            {
                return NotFound();
            }

            return imoveltb;
        }

        // PUT: api/Imoveltbs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutImoveltb(int id, Imoveltb imoveltb)
        {
            if (id != imoveltb.IdImovel)
            {
                return BadRequest();
            }

            _context.Entry(imoveltb).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImoveltbExists(id))
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

        // POST: api/Imoveltbs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Imoveltb>> PostImoveltb(Imoveltb imoveltb)
        {
            _context.Imoveltbs.Add(imoveltb);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetImoveltb", new { id = imoveltb.IdImovel }, imoveltb);
        }

        // DELETE: api/Imoveltbs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImoveltb(int id)
        {
            var imoveltb = await _context.Imoveltbs.FindAsync(id);
            if (imoveltb == null)
            {
                return NotFound();
            }

            _context.Imoveltbs.Remove(imoveltb);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ImoveltbExists(int id)
        {
            return _context.Imoveltbs.Any(e => e.IdImovel == id);
        }
    }
}
