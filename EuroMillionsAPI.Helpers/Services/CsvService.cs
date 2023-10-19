using CsvHelper;
using CsvHelper.Configuration;
using EuroMillionsAPI.Entities;
using EuroMillionsAPI.Helpers.Mappers;
using System.Globalization;

namespace EuroMillionsAPI.Helpers.Services
{
    public class CsvService
    {
        public CsvService() { }

        public List<Draw> getDrawsFromCsvFile(string csvFilePath)
        {
            var readerConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ";",
            };

            using (var csvStreamReader = new StreamReader(csvFilePath))
            using (var csvReader = new CsvReader(csvStreamReader, readerConfig))
            {
                {
                    csvReader.Context.RegisterClassMap<EuromillionsFdjCsvDrawMap>();
                    List<Draw> draws = csvReader.GetRecords<Draw>().ToList();

                    draws.Sort((a, b) => a.DrawDate.CompareTo(b.DrawDate));
                    return draws;
                }
            }

        }
    }
}
