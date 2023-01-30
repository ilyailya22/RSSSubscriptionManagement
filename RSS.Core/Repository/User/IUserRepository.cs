using RSS.Entities.Models.User;

namespace RSS.Core.Repository.User;

public interface IUserRepository
{
    UserInfo CreateUser(UserInfo user);

    UserInfo GetUserById(Guid userId);

    UserInfo GetUserByEmail(string email);

    bool CheckUserForAuth(UserLoginModel loginModel);
}
