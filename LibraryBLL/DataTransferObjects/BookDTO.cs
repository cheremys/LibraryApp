using System;

namespace LibraryBLL.DataTransferObjects
{
    public class BookDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public DateTime? PublicationDate { get; set; }

        public string Description { get; set; }

        public int? CategoryId { get; set; }

        public CategoryDTO Category { get; set; }
    }
}
