using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryDAL.Entities
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public virtual ICollection<Book> Books { get; set; }

        public Category()
        {
            Books = new List<Book>();
        }
    }
}
