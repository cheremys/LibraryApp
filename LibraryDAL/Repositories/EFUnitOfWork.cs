using System;
using LibraryDAL.EF;
using LibraryDAL.Entities;
using LibraryDAL.Interfaces;

namespace LibraryDAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private LibraryContext dataBase;
        private BookRepository bookRepository;
        private CategoryRepository categoryRepository;

        public EFUnitOfWork()
        {
            dataBase = new LibraryContext();
        }

        public IRepository<Book> Books
        {
            get
            {
                return bookRepository != null ? bookRepository
                    : bookRepository = new BookRepository(dataBase);
            }
        }

        public IRepository<Category> Categories
        {
            get
            {
                return categoryRepository != null ? categoryRepository
                    : categoryRepository = new CategoryRepository(dataBase);
            }
        }

        public void Save()
        {
            dataBase.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    dataBase.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
