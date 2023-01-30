using RSS.Entities.Models.User;

namespace RSS.Entities.Db.User;

public class UserService : IUserService
{
    public UserInfo AddUser(UserInfo userInfo)
    {
        using (ApplicationContext db = new ApplicationContext())
        {
            db.Users.Add(userInfo);
            db.SaveChanges();

            return userInfo;
        }
    }

    public UserInfo GetUserById(Guid userId)
    {
        using (ApplicationContext db = new ApplicationContext())
        {
            var userInfo = db.Users.FirstOrDefault(u => u.Id == userId);

            return userInfo;
        }
    }

    public UserInfo GetUserByEmail(string email)
    {
        using (ApplicationContext db = new ApplicationContext())
        {
            var userInfo = db.Users.FirstOrDefault(u => u.Email == email);

            return userInfo;
        }
    }

}
