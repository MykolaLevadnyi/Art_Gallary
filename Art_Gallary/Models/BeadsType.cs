using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Art_Gallary.Models
{
    public class BeadsType
    {
        public BeadsType()
        {
            beads = new List<Bead>();
        }
        public long Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Bead> beads { get; set; }
    }
}
