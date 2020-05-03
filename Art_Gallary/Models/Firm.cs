using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Art_Gallary.Models
{
    public class Firm
    {
        public Firm()
        {
            embroiderics = new List<Embroideric>();
        }
        public long Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Embroideric> embroiderics { get; set; }
    }
}
