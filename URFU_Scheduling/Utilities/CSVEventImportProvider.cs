using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using URFU_Scheduling_lib.Domain.Entities;
using URFU_Scheduling_lib.Domain.Interfaces;

namespace URFU_Scheduling.Utilities
{
    public class CSVEventImportProvider : IEventImportProvider<Stream>
    {
        private static CsvConfiguration _config;

        static CSVEventImportProvider()
        { 
            _config = new CsvConfiguration(CultureInfo.InvariantCulture)
            { 
                Delimiter = ";",
                HasHeaderRecord = false
            };
        }

        public CSVEvent[] Import(Stream csvFile)
        {
            return ReadCSV<CSVEvent>(csvFile).ToArray();
        }

        private static IEnumerable<T> ReadCSV<T>(Stream file)
        {
            var reader = new StreamReader(file);
            var csv = new CsvReader(reader, _config);
            var records = csv.GetRecords<T>();
            return records;
        }
    }
}