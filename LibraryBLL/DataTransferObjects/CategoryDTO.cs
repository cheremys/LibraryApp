using System.Collections.Generic;

namespace LibraryBLL.DataTransferObjects
{
    public class CategoryDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<BookDTO> Books { get; set; }

        public CategoryDTO()
        {
            Books = new List<BookDTO>();
        }
    }
}