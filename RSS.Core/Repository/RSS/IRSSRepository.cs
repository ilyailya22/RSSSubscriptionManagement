using RSS.Entities.Models.RSSItems;
using RSS.Entities.Models.User;

namespace RSS.Core.Repository.RSS;

public interface IRSSRepository
{
    Feed AddFeed(Feed feed);

    IEnumerable<Feed> GetActiveFeeds();

    IEnumerable<News> GetUnreadNewses(DateTime date);

    News SetNewsAsRead(string id);

    IEnumerable<News> GetNewses();

}
