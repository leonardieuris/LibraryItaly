using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoLibrary
{
    public class Logic
    {
        private readonly List<Regione> Italy;
        public Logic(List<Regione> italy)
        {
            Italy = italy;
        }

        public int GetPopolazioneByProvincia(string nomeProvincia)
        {
            var provincia = GetProvinciaByName(nomeProvincia);
            return provincia!=null ? provincia.Comuni.Sum(x => x.Popolazione):0;
        }

        public int GetPopolazioneByRegione(string nomeRegione)
        {
            var regione = GetRegioneByNome(nomeRegione);
            return regione.Provincia.Sum(x => x.Comuni.Sum(y => y.Popolazione));
        }


        public Provincia GetProvinciaByNomeComune(string nomeComune)
        {
            foreach (var regione in Italy)
            {
                foreach (var provincia in regione.Provincia)
                {
                  var result =  provincia.Comuni.Where(x => x.Nome.Equals(nomeComune)).FirstOrDefault();
                    if (result != null)
                        return provincia;
                }
            }

            return null;
        }

        private Regione GetRegioneByNome(string nomeRegione)
        {
            return Italy.Where(x => x.Nome.Equals(nomeRegione)).SingleOrDefault();
        }

        private Provincia GetProvinciaByName(string nomeProvincia)
        {
            
            foreach (var item in Italy)
            {
              var provincia =  item.Provincia
                    .Where(x => x.Nome.Equals(nomeProvincia))
                    .SingleOrDefault();
                if (provincia != null)
                    return provincia;
        
            }

            return null;
        }

        public List<Comune> GetComuniUnder10K()
        {
            List<Comune> lista = new List<Comune>();

            foreach (var item in Italy)
            {
                foreach (var element in item.Provincia)
                {
                    
                    lista.AddRange(element.Comuni.Where(x=>x.Popolazione<10000));
                }
            }

            return lista;
        }
    }
}
