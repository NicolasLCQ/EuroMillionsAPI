namespace EuroMillionsAPI.Synchronizer.Services
{
    using HtmlAgilityPack;

    public class ScrapperServices
    {
        public ScrapperServices() { }

        public HtmlDocument getHtmlFromUrl(string url)
        {
            return new HtmlWeb().Load(url);
        }

        public async Task DownloadFileFromTo(string url, string destinationPath)
        {
            string fileName = url.Split('/').Last();
            string fullPath = destinationPath + "\\" + fileName;

            HttpClient httpClient = new HttpClient();
            var responseStream = await httpClient.GetStreamAsync(url);
            using var fileStream = new FileStream(fullPath, FileMode.Create);

            await responseStream.CopyToAsync(fileStream);
        }
    }
}
