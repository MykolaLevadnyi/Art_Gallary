using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Art_Gallary.Models
{
    public class ShopContext : DbContext
    {
        public virtual DbSet<Bead> Beads { get; set; }
        public virtual DbSet<BeadsToEmbs> BeadsToEmbs { get; set; }
        public virtual DbSet<BeadsType> BeadsTypes { get; set; }
        public virtual DbSet<Color> Colors { get; set; }
        public virtual DbSet<Embroideric> Embroiderics { get; set; }
        public virtual DbSet<EmbType> EmbTypes { get; set; }
        public virtual DbSet<Firm> Firms { get; set; }
        public virtual DbSet<Size> Sizes { get; set; }

        public ShopContext(DbContextOptions<ShopContext> options)
            :base(options)
        {
            Database.EnsureCreated();
        }


    }
}
