
using Microsoft.AspNetCore.Mvc;
using Ninject;
using RSS.Core;
using RSS.Core.Repository.User;
using RSS.Entities.Models.User;

namespace RSS.Api.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController : Controller
{
    private readonly IUserRepository _userRepository;

    public UsersController()
    {
        _userRepository = Bootstrapper.Kernel.Get<IUserRepository>();
    }

    [HttpPost]
    public ActionResult<UserInfo> Post(UserInfo userInfo)
    {
        var user = _userRepository.CreateUser(userInfo);
        return Ok(user);
    }
}
