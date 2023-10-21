using EuroMillionsAPI.Entities;
using EuroMillionsAPI.Helpers.Services;
namespace EuroMillionsAPI.Helpers
{
    public class CsvParser
    {
        private readonly CsvService csvService;

        public CsvParser()
        {
            this.csvService = new CsvService();
        }

        public List<Draw> getAllDrawsFromDirectoryContainingEuromillionCsvFiles(string PathToCsvFiles)
        {
            var csvFiles = Directory.GetFiles(PathToCsvFiles);

            List<Draw> draws = new List<Draw>();
            foreach (var csvFile in csvFiles)
            {
                foreach (var draw in csvService.getDrawsFromCsvFile(csvFile))
                {
                    draws.Add(draw);
                }
                File.Delete(csvFile);
            }
            return draws;
        }
    }
}
