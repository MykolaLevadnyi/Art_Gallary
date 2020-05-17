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
    public class BeadsController : ControllerBase
    {
        private readonly ShopContext _context;
        
        public BeadsController(ShopContext context)
        {
            _context = context;
        }

        
        // GET: api/Beads
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bead>>> GetBeads()
        {
            return await _context.Beads.ToListAsync();
        }

        // GET: api/Beads/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bead>> GetBead(long id)
        {
            var bead = await _context.Beads.FindAsync(id);

            if (bead == null)
            {
                return NotFound();
            }

            return bead;
        }

        // PUT: api/Beads/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBead(long id, Bead bead)
        {
            var num = _context.Beads.Where(e => e.Num == bead.Num).FirstOrDefault();
            if (num == null)
            {
                if (id != bead.Id)
                {
                    return BadRequest();
                }

                _context.Entry(bead).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BeadExists(id))
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

        // POST: api/Beads
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Bead>> PostBead(Bead bead)
        {
            
            var num = _context.Beads.Where(e => e.Num == bead.Num).FirstOrDefault();
            var image = _context.Beads.Where(e => e.Image == bead.Image).FirstOrDefault();
            
            
            if (num == null && image == null)
            {
                _context.Beads.Add(bead);
                await _context.SaveChangesAsync();
            }
            
            return CreatedAtAction("GetBead", new { id = bead.Id }, bead);
        }

        // DELETE: api/Beads/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Bead>> DeleteBead(long id)
        {
            var bead = await _context.Beads.FindAsync(id);
            if (bead == null)
            {
                return NotFound();
            }

            _context.Beads.Remove(bead);
            await _context.SaveChangesAsync();

            return bead;
        }

        private bool BeadExists(long id)
        {
            return _context.Beads.Any(e => e.Id == id);
        }
    }
}
