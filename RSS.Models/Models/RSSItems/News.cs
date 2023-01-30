using RSS.Entities.Models.Enums;

namespace RSS.Entities.Models.RSSItems;

public class News
{
    public string Id { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public string Link { get; set; }

    public string Category { get; set; }

    public DateTime Date { get; set; }

    public NewsStatus Status { get; set; }
}
