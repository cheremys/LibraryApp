using LibraryBLL.Interfaces;
using LibraryBLL.Services;
using Ninject.Modules;

namespace LibraryWeb.Util
{
    public class BookModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IBookService>().To<BookService>();
        }
    }
}