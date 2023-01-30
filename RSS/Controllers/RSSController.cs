using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using Ninject;
using RSS.Api.Session;
using RSS.Core;
using RSS.Core.Repository.RSS;
using RSS.Entities.Models.RSSItems;

namespace RSS.Api.Test;

[ApiController]
[Route("api/rss")]
public class RSSController : Controller
{
    private readonly IRSSRepository _rssRepository;

    public RSSController()
    {
        _rssRepository = Bootstrapper.Kernel.Get<IRSSRepository>();
    }

    [HttpPost]
    [Route("PostNewFeed")]
    public ActionResult<Feed> PostFeed(Feed feed)
    {
        var token = HttpContext.Request.Headers[HeaderNames.Authorization];
        var userId = SessionHandler.GetUserIdByToken(token);

        if (userId != null)
        {
            var created = _rssRepository.AddFeed(feed);
            return Ok(created);
        }
        else
        {
            return Unauthorized();
        }
    }


    [HttpGet]
    [Route("GetAllActiveFeeds")]
    public ActionResult<IEnumerable<Feed>> GetActiveFeeds()
    {
        var token = HttpContext.Request.Headers[HeaderNames.Authorization];
        var userId = SessionHandler.GetUserIdByToken(token);

        if (userId != null)
        {
            var feeds = _rssRepository.GetActiveFeeds();
            return Ok(feeds);
        }
        else
        {
            return Unauthorized();
        }
    }

    [HttpPut]
    [Route("SetNewsAsReed")]
    public ActionResult<News> PutNews(string id)
    {
        var token = HttpContext.Request.Headers[HeaderNames.Authorization];
        var userId = SessionHandler.GetUserIdByToken(token);

        if (userId != null)
        {
            var news = _rssRepository.SetNewsAsRead(id);
            return Ok(news);
        }
        else
        {
            return Unauthorized();
        }
    }


    [HttpGet]
    [Route("GetUnreadNewses")]
    public ActionResult<IEnumerable<News>> GetUnreadNewses(DateTime date)
    {
        var token = HttpContext.Request.Headers[HeaderNames.Authorization];
        var userId = SessionHandler.GetUserIdByToken(token);

        if (userId != null)
        {
            var newses = _rssRepository.GetUnreadNewses(date);
            return Ok(newses);
        }
        else
        {
            return Unauthorized();
        }
    }

    [HttpGet]
    [Route("GetNewses")]
    public ActionResult<IEnumerable<News>> GetNewses()
    {
        var token = HttpContext.Request.Headers[HeaderNames.Authorization];
        var userId = SessionHandler.GetUserIdByToken(token);

        if (userId != null)
        {
            var newses = _rssRepository.GetNewses();
            return Ok(newses);
        }
        else
        {
            return Unauthorized();
        }
    }



}
