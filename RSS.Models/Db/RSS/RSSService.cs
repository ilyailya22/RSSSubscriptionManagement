using RSS.Entities.Helpers;
using RSS.Entities.Models.Enums;
using RSS.Entities.Models.RSSItems;

namespace RSS.Entities.Db.RSS;

public class RSSService : IRSSService
{

    public Feed AddFeed(Feed feed)
    {
        using (ApplicationContext db = new ApplicationContext())
        {
            db.Feeds.Add(feed);
            db.SaveChanges();
            var newsList = RSSHelper.read(feed.Url);
            foreach(var news in newsList)
            {
                db.Newses.Add(news);
            }
            db.SaveChanges();

            return feed;
        }
    }

    public IEnumerable<Feed> GetActiveFeeds()
    {
        using (ApplicationContext db = new ApplicationContext())
        {
            var feeds = db.Feeds.Where(x => x.Status == FeedStatus.active).ToList();
            return feeds;
        }
    }

    public IEnumerable<News> GetUnreadNewses(DateTime date)
    {
        using (ApplicationContext db = new ApplicationContext())
        {
            var newses = db.Newses.Where(x => x.Status == NewsStatus.unread && x.Date.Date == date.Date).ToList();
            return newses;
        }
    }

    public IEnumerable<News> GetNewses()
    {
        using (ApplicationContext db = new ApplicationContext())
        {
            var newses = db.Newses.ToList();
            return newses;
        }
    }

    public News SetNewsAsRead(string id)
    {
        using (ApplicationContext db = new ApplicationContext())
        {
            var news = db.Newses.FirstOrDefault(x => x.Id == id);
            news.Status = NewsStatus.reeded;
            db.Newses.Update(news);
            db.SaveChanges();
            return news;
        }
    }
}
