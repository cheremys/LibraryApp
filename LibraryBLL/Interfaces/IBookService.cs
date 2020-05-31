using System.Collections.Generic;
using LibraryBLL.DataTransferObjects;

namespace LibraryBLL.Interfaces
{
    public interface IBookService
    {
        void CreateBook(BookDTO book);

        BookDTO GetBook(int? id);

        BookDTO FindBookByName(string name);

        IEnumerable<BookDTO> GetBooks();

        void Delete(int id);

        void Dispose();
    }
}
