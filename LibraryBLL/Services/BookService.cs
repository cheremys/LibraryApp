using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using LibraryBLL.DataTransferObjects;
using LibraryBLL.Infrastructure;
using LibraryBLL.Interfaces;
using LibraryDAL.Entities;
using LibraryDAL.Interfaces;

namespace LibraryBLL.Services
{
    public class BookService : IBookService
    {
        IUnitOfWork Database { get; set; }

        public BookService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void CreateBook(BookDTO bookDTO)
        {
            if (bookDTO == null)
            {
                throw new ValidationException("There is no such book", "");
            }

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<BookDTO, Book>()).CreateMapper();
            var book = mapper.Map<BookDTO, Book>(bookDTO);

            Database.Books.Create(book);
            Database.Save();
        }

        public BookDTO GetBook(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("There is no such book", "");
            }

            var book = Database.Books.Get(id.Value);

            if (book == null)
            {
                throw new ValidationException("There is no such book", "");
            }

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Book, BookDTO>()).CreateMapper();
            return mapper.Map<Book, BookDTO>(book);
        }

        public BookDTO FindBookByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ValidationException("There is no such book", "");
            }

            var book = Database.Books.Find(s => s.Title == name).FirstOrDefault();

            if (book == null)
            {
                throw new ValidationException("There is no such book", "");
            }

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Book, BookDTO>()).CreateMapper();
            return mapper.Map<Book, BookDTO>(book);
        }

        public IEnumerable<BookDTO> GetBooks()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Book, BookDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Book>, List<BookDTO>>(Database.Books.GetAll());

        }

        public void Delete(int id)
        {
            Database.Books.Delete(id);
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
