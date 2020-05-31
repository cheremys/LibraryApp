using LibraryDAL.Interfaces;
using LibraryDAL.Repositories;
using Ninject.Modules;

namespace LibraryBLL.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitOfWork>().To<EFUnitOfWork>();
        }
    }
}
