using Microsoft.EntityFrameworkCore;
using RSS.Entities.Models.RSSItems;
using RSS.Entities.Models.User;

namespace RSS.Entities.Db;

public class ApplicationContext : DbContext
{
    public ApplicationContext()
    {
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySQL($"server=localhost;port=3307;database=rss;user=user;password=password");
    }

    public DbSet<UserInfo> Users { get; set; }

    public DbSet<Feed> Feeds { get; set; }

    public DbSet<News> Newses { get; set; }


}
