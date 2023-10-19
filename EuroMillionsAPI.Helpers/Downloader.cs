using EuroMillionsAPI.Helpers.Services;
using System.IO.Compression;

namespace EuroMillionsAPI.Helpers
{
    public class Downloader
    {
        private readonly ScrapperServices scrapperServices;
        private readonly ParserServices parserServices;

        public Downloader()
        {
            this.parserServices = new ParserServices();
            this.scrapperServices = new ScrapperServices();
        }

        public void DownloadDrawResultFromFdjHistoryToDir(string directoryPath)
        {
            //Get Links
            List<string> links = parserServices.getDownloadLinksFromFdjHistoryHtmlPage(
                scrapperServices.getHtmlFromUrl("https://www.fdj.fr/jeux-de-tirage/euromillions-my-million/historique")
            );

            //Download links
            var downloadTasks = new List<Task>();
            foreach (string link in links)
            {
                downloadTasks.Add(scrapperServices.DownloadFileFromTo(link, directoryPath));
            }
            Task.WhenAll(downloadTasks).Wait();

            //Unzip File
            var archives = Directory.GetFiles(directoryPath);
            foreach (string archive in archives)
            {
                ZipFile.ExtractToDirectory(archive, directoryPath);
                File.Delete(archive);
            }
        }
    }
}