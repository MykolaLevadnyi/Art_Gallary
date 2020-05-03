using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Art_Gallary.Models
{
    public class Bead
    {
        public Bead() {
            beadstoembs = new List<BeadsToEmbs>();
        }
        public long Id { get; set; }
        public long ColorId { get; set; }
        public string Num { get; set; }
        public long BeadsTypeId { get; set; }
        public byte[] Image { get; set; }
        public virtual BeadsType type { get; set; }
        public virtual Color color { get; set; }
        public virtual ICollection<BeadsToEmbs> beadstoembs { get; set; }

    }
}
