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
    public class EmbroidericsController : ControllerBase
    {
        private readonly ShopContext _context;

        public EmbroidericsController(ShopContext context)
        {
            _context = context;
        }

        // GET: api/Embroiderics
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Embroideric>>> GetEmbroiderics()
        {
            return await _context.Embroiderics.ToListAsync();
        }

        // GET: api/Embroiderics/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Embroideric>> GetEmbroideric(long id)
        {
            var embroideric = await _context.Embroiderics.FindAsync(id);

            if (embroideric == null)
            {
                return NotFound();
            }

            return embroideric;
        }

        // PUT: api/Embroiderics/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmbroideric(long id, Embroideric embroideric)
        {
            if (id != embroideric.Id)
            {
                return BadRequest();
            }

            _context.Entry(embroideric).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmbroidericExists(id))
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

        // POST: api/Embroiderics
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Embroideric>> PostEmbroideric(Embroideric embroideric)
        {
            _context.Embroiderics.Add(embroideric);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmbroideric", new { id = embroideric.Id }, embroideric);
        }

        // DELETE: api/Embroiderics/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Embroideric>> DeleteEmbroideric(long id)
        {
            var embroideric = await _context.Embroiderics.FindAsync(id);
            if (embroideric == null)
            {
                return NotFound();
            }

            _context.Embroiderics.Remove(embroideric);
            await _context.SaveChangesAsync();

            return embroideric;
        }

        private bool EmbroidericExists(long id)
        {
            return _context.Embroiderics.Any(e => e.Id == id);
        }
    }
}
