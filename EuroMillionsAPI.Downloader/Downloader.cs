using EuroMillionsAPI.Synchronizer.Services;
using System.IO.Compression;

namespace EuroMillionsAPI.Synchronizer
{
    public class Downloader
    {
        private ScrapperServices scrapperServices;
        private ParserServices parserServices;

        public Downloader()
        {
            this.parserServices = new ParserServices();
            this.scrapperServices = new ScrapperServices();
        }

        public string DownloadDrawResultFromFdjHistory()
        {
            //Get Links
            List<string> links = parserServices.getDownloadLinksFromFdjHistoryHtmlPage(
                scrapperServices.getHtmlFromUrl("https://www.fdj.fr/jeux-de-tirage/euromillions-my-million/historique")
            );

            //Download links
            var directoryObject = Directory.CreateTempSubdirectory();

            var downloadTasks = new List<Task>();
            foreach (string link in links)
            {
                downloadTasks.Add(scrapperServices.DownloadFileFromTo(link, directoryObject.FullName));
            }
            Task.WhenAll(downloadTasks).Wait();

            //Unzip File
            var archives = Directory.GetFiles(directoryObject.FullName);
            foreach (string archive in archives)
            {
                ZipFile.ExtractToDirectory(archive, directoryObject.FullName);
                File.Delete(archive);
            }

            return directoryObject.FullName;
        }
    }
}