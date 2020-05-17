using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Art_Gallary.Models
{
    public interface IRepository
    {
        IEnumerable<Bead> GetAll();
        Bead Get(int id);
        void Create(Bead user);
    }
}
