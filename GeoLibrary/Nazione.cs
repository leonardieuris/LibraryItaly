using LibraryItaly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoLibrary
{
    public class Nazione
    {
        public IEnumerable<Regione> GetNazione(IEnumerable<GeoCSV> listaRows)
        {
            var comuni = listaRows.Select(x =>
            new Comune
            {
                Nome = x.Comune,
                Popolazione = x.Popolazione
            });

            var provincie = listaRows
                .Select(
                x=> new Provincia
                {
                    Nome =x.Provincia,
                    Targa = x.Targa,
                    Comuni = comuni
                    .Where(c=>c.Nome.Equals(x.Comune))
                                    }
                );

            var regioni = listaRows.Select(
                x => new Regione
                {
                    Nome = x.Regione,
                    Provincia = provincie
                    .Where(p => p.Nome == x.Provincia)
                }
                );

            return regioni;
        }

    }
}
