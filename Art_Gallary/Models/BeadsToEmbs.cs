using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Art_Gallary.Models
{
    public class BeadsToEmbs
    {
        public long Id { get; set; }
        public long BeadId { get; set; }
        public long EmbroidericId { get; set; }
        public virtual Bead bead { get; set; }
        public virtual Embroideric embroideric { get; set; }
    }
}
