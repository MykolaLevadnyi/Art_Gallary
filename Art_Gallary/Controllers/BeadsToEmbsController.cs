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
    public class BeadsToEmbsController : ControllerBase
    {
        private readonly ShopContext _context;

        public BeadsToEmbsController(ShopContext context)
        {
            _context = context;
        }

        // GET: api/BeadsToEmbs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BeadsToEmbs>>> GetBeadsToEmbs()
        {
            return await _context.BeadsToEmbs.ToListAsync();
        }

        // GET: api/BeadsToEmbs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BeadsToEmbs>> GetBeadsToEmbs(long id)
        {
            var beadsToEmbs = await _context.BeadsToEmbs.FindAsync(id);

            if (beadsToEmbs == null)
            {
                return NotFound();
            }

            return beadsToEmbs;
        }

        // PUT: api/BeadsToEmbs/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBeadsToEmbs(long id, BeadsToEmbs beadsToEmbs)
        {
            var r = _context.BeadsToEmbs.Where(b => b.BeadId == beadsToEmbs.BeadId && b.EmbroidericId == beadsToEmbs.EmbroidericId).FirstOrDefault();
            if (r == null) { 
            if (id != beadsToEmbs.Id)
            {
                return BadRequest();
            }

            _context.Entry(beadsToEmbs).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BeadsToEmbsExists(id))
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

        // POST: api/BeadsToEmbs
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<BeadsToEmbs>> PostBeadsToEmbs(BeadsToEmbs beadsToEmbs)
        {
            var r = _context.BeadsToEmbs.Where(b => b.BeadId == beadsToEmbs.BeadId && b.EmbroidericId == beadsToEmbs.EmbroidericId).FirstOrDefault();
            if (r == null)
            {
                _context.BeadsToEmbs.Add(beadsToEmbs);
                await _context.SaveChangesAsync();
            }
            return CreatedAtAction("GetBeadsToEmbs", new { id = beadsToEmbs.Id }, beadsToEmbs);
        }

        // DELETE: api/BeadsToEmbs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BeadsToEmbs>> DeleteBeadsToEmbs(long id)
        {
            var beadsToEmbs = await _context.BeadsToEmbs.FindAsync(id);
            if (beadsToEmbs == null)
            {
                return NotFound();
            }

            _context.BeadsToEmbs.Remove(beadsToEmbs);
            await _context.SaveChangesAsync();

            return beadsToEmbs;
        }

        private bool BeadsToEmbsExists(long id)
        {
            return _context.BeadsToEmbs.Any(e => e.Id == id);
        }
    }
}
