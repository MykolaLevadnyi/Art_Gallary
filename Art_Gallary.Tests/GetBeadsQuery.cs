using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Art_Gallary.Models;

namespace Art_Gallary
{
    public class GetBeadsQuery
    {
        private readonly ShopContext _context;

        public GetBeadsQuery(ShopContext context)
        {
            _context = context;
        }
        public IList<Bead> Execute()
        {
            return _context.Beads
                .OrderBy(c => c.Id)
                .ToList();
        }
        
    }
}
