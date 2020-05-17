using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Art_Gallary.Models;

namespace Art_Gallary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmbTypesController : ControllerBase
    {
        private readonly ShopContext _context;

        public EmbTypesController(ShopContext context)
        {
            _context = context;
        }

        // GET: api/EmbTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmbType>>> GetEmbTypes()
        {
            return await _context.EmbTypes.ToListAsync();
        }

        // GET: api/EmbTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmbType>> GetEmbType(long id)
        {
            var embType = await _context.EmbTypes.FindAsync(id);

            if (embType == null)
            {
                return NotFound();
            }

            return embType;
        }

        // PUT: api/EmbTypes/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmbType(long id, EmbType embType)
        {
            var name = _context.EmbTypes.Where(e => e.Name == embType.Name).FirstOrDefault();
            if (name == null)
            {
                if (id != embType.Id)
                {
                    return BadRequest();
                }

                _context.Entry(embType).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmbTypeExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return NoContent();
        }

        // POST: api/EmbTypes
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<EmbType>> PostEmbType(EmbType embType)
        {
            var name = _context.EmbTypes.Where(e => e.Name == embType.Name).FirstOrDefault();
            if (name == null) { 
            _context.EmbTypes.Add(embType);
            await _context.SaveChangesAsync();
            }
            return CreatedAtAction("GetEmbType", new { id = embType.Id }, embType);
        }

        // DELETE: api/EmbTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EmbType>> DeleteEmbType(long id)
        {
            var embType = await _context.EmbTypes.FindAsync(id);
            if (embType == null)
            {
                return NotFound();
            }

            _context.EmbTypes.Remove(embType);
            await _context.SaveChangesAsync();

            return embType;
        }

        private bool EmbTypeExists(long id)
        {
            return _context.EmbTypes.Any(e => e.Id == id);
        }
    }
}
