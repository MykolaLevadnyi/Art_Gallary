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
    public class BeadsTypesController : ControllerBase
    {
        private readonly ShopContext _context;

        public BeadsTypesController(ShopContext context)
        {
            _context = context;
        }

        // GET: api/BeadsTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BeadsType>>> GetBeadsTypes()
        {
            return await _context.BeadsTypes.ToListAsync();
        }

        // GET: api/BeadsTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BeadsType>> GetBeadsType(long id)
        {
            var beadsType = await _context.BeadsTypes.FindAsync(id);

            if (beadsType == null)
            {
                return NotFound();
            }

            return beadsType;
        }

        // PUT: api/BeadsTypes/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBeadsType(long id, BeadsType beadsType)
        {
            if (id != beadsType.Id)
            {
                return BadRequest();
            }

            _context.Entry(beadsType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BeadsTypeExists(id))
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

        // POST: api/BeadsTypes
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<BeadsType>> PostBeadsType(BeadsType beadsType)
        {
            _context.BeadsTypes.Add(beadsType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBeadsType", new { id = beadsType.Id }, beadsType);
        }

        // DELETE: api/BeadsTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BeadsType>> DeleteBeadsType(long id)
        {
            var beadsType = await _context.BeadsTypes.FindAsync(id);
            if (beadsType == null)
            {
                return NotFound();
            }

            _context.BeadsTypes.Remove(beadsType);
            await _context.SaveChangesAsync();

            return beadsType;
        }

        private bool BeadsTypeExists(long id)
        {
            return _context.BeadsTypes.Any(e => e.Id == id);
        }
    }
}
