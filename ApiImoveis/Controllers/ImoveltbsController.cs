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

        // GET: api/Imoveltbs/id/5
        [HttpGet("id/{id}")]
        public async Task<ActionResult<Imoveltb>> GetImoveltb(int id)
        {
            var imoveltb = await _context.Imoveltbs.FindAsync(id);

            if (imoveltb == null)
            {
                return NotFound();
            }

            return imoveltb;
        }

        // GET: api/Imoveltbs/cidade
        [HttpGet("cidade/{cidade}")]
        public ActionResult<Imoveltb> GetImoveltbcidade(string cidade)
        {
            var imoveltb = (from imovel in _context.Imoveltbs where imovel.Cidade.Equals(cidade) select imovel).ToList();

            if (imoveltb == null)
            {
                return NotFound();
            }

            return Ok(imoveltb);
        }

        // GET: api/Imoveltbs/estado
        [HttpGet("estado/{estado}")]
        public ActionResult<Imoveltb> GetImoveltbestado(string estado)
        {
            var imoveltb = (from imovel in _context.Imoveltbs where imovel.Estado.Equals(estado) select imovel).ToList();

            if (imoveltb == null)
            {
                return NotFound();
            }

            return Ok(imoveltb);
        }

        // GET: api/Imoveltbs/bairro
        [HttpGet("bairro/{bairro}")]
        public ActionResult<Imoveltb> GetImoveltbbairro(string bairro)
        {
            var imoveltb = (from imovel in _context.Imoveltbs where imovel.Bairro.Equals(bairro) select imovel).ToList();

            if (imoveltb == null)
            {
                return NotFound();
            }

            return Ok(imoveltb);
        }

        // GET: api/Imoveltbs/cep
        [HttpGet("cep/{cep}")]
        public ActionResult<Imoveltb> GetImoveltbcep(int cep)
        {
            var imoveltb = (from imovel in _context.Imoveltbs where imovel.Cep.Equals(cep) select imovel).ToList();

            if (imoveltb == null)
            {
                return NotFound();
            }

            return Ok(imoveltb);
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

        // DELETE: api/Imoveltbs/id/5
        [HttpDelete("id/{id}")]
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

        // DELETE: api/Imoveltbs/cep/11111111/num/1111
        [HttpDelete("cep/{cep}/num/{num}")]
        public async Task<IActionResult> DeleteImoveltbCompleto(int cep,string num)
        {
            var imoveltb = _context.Imoveltbs.Where(x => x.Cep == cep && x.Numero.Equals(num)).FirstOrDefault();
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
