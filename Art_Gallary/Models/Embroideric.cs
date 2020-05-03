using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Art_Gallary.Models
{
    public class Embroideric
    {
        public Embroideric()
        {
            beadstoembs = new List<BeadsToEmbs>();
        }

        public long Id { get; set; }
        public long SizeId { get; set; }
        public long FirmId { get; set; }
        public long EmbTypeId { get; set; }
        public string Name { get; set; }
        public string Num { get; set; }
        public byte[] Image { get; set; }
        public double Price { get; set; }

        public virtual Firm firm { get; set; }
        public virtual Size size { get; set; }
        public virtual EmbType type { get; set; }

        public virtual ICollection<BeadsToEmbs> beadstoembs { get; set; }

    }
}
