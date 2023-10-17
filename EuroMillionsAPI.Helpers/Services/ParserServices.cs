using HtmlAgilityPack;

namespace EuroMillionsAPI.Synchronizer.Services
{
    public class ParserServices
    {
        public ParserServices() { }

        public List<string> getDownloadLinksFromFdjHistoryHtmlPage(HtmlDocument html)
        {
            List<string> result = new List<string>();

            HtmlNodeCollection euromillionsAndMyMillionsDiv = html.DocumentNode.SelectNodes("//*[@id=\"page-chart\"]/section[4]/div");
            IEnumerable<HtmlNode> links = euromillionsAndMyMillionsDiv.Descendants("a");
            foreach (HtmlNode link in links)
            {
                result.Add(link.Attributes["href"].Value);
            }
            return result;
        }
    }
}
