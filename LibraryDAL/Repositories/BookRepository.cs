using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using LibraryDAL.EF;
using LibraryDAL.Entities;
using LibraryDAL.Interfaces;

namespace LibraryDAL.Repositories
{
    public class BookRepository : IRepository<Book>
    {
        private LibraryContext dataBase;

        public BookRepository(LibraryContext context)
        {
            this.dataBase = context;
        }

        public IEnumerable<Book> GetAll()
        {
            return dataBase.Books;
        }

        public Book Get(int id)
        {
            return dataBase.Books.Find(id);
        }

        public void Create(Book book)
        {
            dataBase.Books.Add(book);
        }

        public void Update(Book book)
        {
            dataBase.Entry(book).State = EntityState.Modified;
        }

        public IEnumerable<Book> Find(Func<Book, bool> predicate)
        {
            return dataBase.Books.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Book book = dataBase.Books.Find(id);
            if (book != null)
            {
                dataBase.Books.Remove(book);
                dataBase.SaveChanges();
            }
        }
    }
}
