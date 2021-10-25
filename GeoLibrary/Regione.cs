using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoLibrary
{
    public class Regione : Entity
    {
        public List<Provincia> Provincia {get;set;}
    }
}
