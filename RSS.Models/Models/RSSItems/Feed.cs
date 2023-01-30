using RSS.Entities.Models.Enums;

namespace RSS.Entities.Models.RSSItems;

public class Feed
{
    public string Id { get; set; }

    public string Url { get; set; }

    public FeedStatus Status { get; set; }

}
