
using RSS.Entities.Models.User;

namespace RSS.Entities.Db.User;

public interface IUserService
{
    UserInfo AddUser(UserInfo userInfo);

    UserInfo GetUserById(Guid userId);

    UserInfo GetUserByEmail(string email);

}
