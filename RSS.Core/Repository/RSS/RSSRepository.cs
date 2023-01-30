using RSS.Entities.Models.User;
using RSS.Entities.Db.User;
using RSS.Entities.Db.RSS;
using RSS.Entities.Models.RSSItems;

namespace RSS.Core.Repository.RSS;

public class RSSRepository : IRSSRepository
{
    private readonly IRSSService _rssService;

    public RSSRepository(IRSSService rssService)
    {
        _rssService = rssService;
    }

    public Feed AddFeed(Feed feed)
    {
        var created = _rssService.AddFeed(feed);

        return created;
    }

    public IEnumerable<Feed> GetActiveFeeds()
    {
        var feeds = _rssService.GetActiveFeeds();

        return feeds;
    }

    public IEnumerable<News> GetUnreadNewses(DateTime date)
    {
        var newses = _rssService.GetUnreadNewses(date);

        return newses;
    }

    public News SetNewsAsRead(string id)
    {
        var news = _rssService.SetNewsAsRead(id);

        return news;
    }

    public IEnumerable<News> GetNewses()
    {
        var newses = _rssService.GetNewses();

        return newses;
    }
}
