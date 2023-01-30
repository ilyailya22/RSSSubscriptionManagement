using RSS.Entities.Models.RSSItems;
using RSS.Entities.Models.User;

namespace RSS.Entities.Db.RSS;

public interface IRSSService
{
    Feed AddFeed(Feed feed);

    IEnumerable<Feed> GetActiveFeeds();

    IEnumerable<News> GetUnreadNewses(DateTime date);

    News SetNewsAsRead(string id);

    IEnumerable<News> GetNewses();

}
