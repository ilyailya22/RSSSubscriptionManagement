using RSS.Entities.Models.Enums;
using RSS.Entities.Models.RSSItems;
using System.Globalization;
using System.Xml.XPath;

namespace RSS.Entities.Helpers;

public class RSSHelper
{
    public static List<News> read(string url)
    {
        List<News> listItems = new List<News>();
        try
        {
            XPathDocument doc = new XPathDocument(url);
            XPathNavigator navigator = doc.CreateNavigator();
            XPathNodeIterator nodes = navigator.Select("//item");
            string parseFormat = "ddd, dd MMM yyyy HH:mm:ss zzz";
            while (nodes.MoveNext())
            {
                XPathNavigator node = nodes.Current;
                listItems.Add(new News
                {
                    Category = node.SelectSingleNode("category").Value,
                    Description = node.SelectSingleNode("description").Value,
                    Id = node.SelectSingleNode("guid").Value,
                    Link = node.SelectSingleNode("link").Value,
                    Date = DateTime.ParseExact(node.SelectSingleNode("pubDate").Value,parseFormat,
                                                      CultureInfo.InvariantCulture),
                    Title = node.SelectSingleNode("title").Value,
                    Status = NewsStatus.unread
                });
            }
        }
        catch
        {
            listItems = null;
        }

        return listItems;
    }
}
