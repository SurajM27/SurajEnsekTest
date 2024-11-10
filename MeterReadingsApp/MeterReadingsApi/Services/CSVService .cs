using CsvHelper;
using System.Globalization;

namespace MeterReadingsApp.Services
{
    public class CSVService : ICSVService
    {
        public IEnumerable<T> ReadCSV<T>(Stream file)
        {
            var reader = new StreamReader(file);
            var csv = new CsvReader(reader, CultureInfo.GetCultureInfo("en-GB"));

            var records = csv.GetRecords<T>();
            return records;
        }
    }
}
