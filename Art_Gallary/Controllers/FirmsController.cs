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
    public class FirmsController : ControllerBase
    {
        private readonly ShopContext _context;

        public FirmsController(ShopContext context)
        {
            _context = context;
        }

        // GET: api/Firms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Firm>>> GetFirms()
        {
            return await _context.Firms.ToListAsync();
        }

        // GET: api/Firms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Firm>> GetFirm(long id)
        {
            var firm = await _context.Firms.FindAsync(id);

            if (firm == null)
            {
                return NotFound();
            }

            return firm;
        }

        // PUT: api/Firms/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFirm(long id, Firm firm)
        {
            var f = _context.Firms.Where(f => f.Name == firm.Name).FirstOrDefault();
            if (f == null)
            {
                if (id != firm.Id)
                {
                    return BadRequest();
                }

                _context.Entry(firm).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FirmExists(id))
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

        // POST: api/Firms
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Firm>> PostFirm(Firm firm)
        {
            var f = _context.Firms.Where(f => f.Name == firm.Name).FirstOrDefault();
            if (f == null) { 
            _context.Firms.Add(firm);
            await _context.SaveChangesAsync();
            }

            return CreatedAtAction("GetFirm", new { id = firm.Id }, firm);
        }

        // DELETE: api/Firms/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Firm>> DeleteFirm(long id)
        {
            var firm = await _context.Firms.FindAsync(id);
            if (firm == null)
            {
                return NotFound();
            }

            _context.Firms.Remove(firm);
            await _context.SaveChangesAsync();

            return firm;
        }

        private bool FirmExists(long id)
        {
            return _context.Firms.Any(e => e.Id == id);
        }
    }
}
