using RSS.Entities.Models.User;
using RSS.Entities.Db.User;

namespace RSS.Core.Repository.User;

public class UserRepository : IUserRepository
{
    private readonly IUserService _userService;

    public UserRepository(IUserService userService)
    {
        _userService = userService;
    }

    public UserInfo CreateUser(UserInfo user)
    {
        var created = _userService.AddUser(user);

        return created;
    }

    public UserInfo GetUserById(Guid userId)
    {
        var user = _userService.GetUserById(userId);

        return user;
    }

    public UserInfo GetUserByEmail(string email)
    {
        var user = _userService.GetUserByEmail(email);

        return user;
    }

    public bool CheckUserForAuth(UserLoginModel loginModel)
    {
        var user = GetUserByEmail(loginModel.Email);

        if (user == null)
        {
            return false;
        }

        return user.Password == loginModel.Password;
    }
}
