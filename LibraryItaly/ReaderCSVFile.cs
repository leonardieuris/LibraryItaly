using CsvHelper;
using CsvHelper.Configuration;
using System.IO;
using System.Collections.Generic;

namespace LibraryItaly
{
    public class ReaderCSVFile
    {
        public IEnumerable<GeoCSV> Read(string pathFile)
        {
            var csvConfig = new CsvConfiguration(System.Globalization.CultureInfo.CurrentCulture);
            csvConfig.HasHeaderRecord = true;


            using (var streamReader = new StreamReader(pathFile))
            using (var csvReader = new CsvReader(streamReader,csvConfig))
            {
                foreach (var element in csvReader.GetRecords<GeoCSV>())
                {
                    yield return element;
                }
            }
        }
    }
}
