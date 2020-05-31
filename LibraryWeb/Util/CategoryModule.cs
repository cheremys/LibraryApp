using LibraryBLL.Interfaces;
using LibraryBLL.Services;
using Ninject.Modules;

namespace LibraryWeb.Util
{
    public class CategoryModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ICategoryService>().To<CategoryService>();
        }
    }
}