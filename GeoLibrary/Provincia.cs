using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoLibrary
{
    public class Provincia : Entity
    {
        public IEnumerable<Comune> Comuni { get; set; }
        public string Targa { get; set; }

    }
}
