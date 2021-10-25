using System;
using System.Collections.Generic;
using GeoLibrary;
using LibraryItaly;
using System.Linq;

namespace MyProgram
{
    class Program
    {
        private static string _pathFile = @"C:\DATA\Elenco-comuni-italiani.csv";
        static void Main(string[] args)
        {
            Execute();
        }


        private static void Execute()
        {
            var reader = new ReaderCSVFile();
            var italyFile = reader.Read(_pathFile);
            var creaNazione = new Nazione();
            IEnumerable<Regione> italy = creaNazione.GetNazione(italyFile);
            var logic = new Logic(italy.ToList());
            var comunisotto10kabitanti = logic.GetComuniUnder10K();

        }
    }
}
