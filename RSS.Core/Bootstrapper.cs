using Ninject;
using RSS.Core.Repository.RSS;
using RSS.Core.Repository.User;
using RSS.Entities.Db.RSS;
using RSS.Entities.Db.User;

namespace RSS.Core;
public class Bootstrapper
{
    public Bootstrapper()
    {
        Kernel = new StandardKernel();
        InitializeDependencies();
    }

    public static IKernel Kernel { get; private set; }

    private void InitializeDependencies()
    {
        Kernel.Bind<IUserService>().To<UserService>();
        Kernel.Bind<IUserRepository>().To<UserRepository>();
        Kernel.Bind<IRSSService>().To<RSSService>();
        Kernel.Bind<IRSSRepository>().To<RSSRepository>();
    }
}

