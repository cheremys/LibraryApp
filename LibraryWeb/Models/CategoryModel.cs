using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryWeb.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public virtual ICollection<BookModel> Books { get; set; }

        public CategoryModel()
        {
            Books = new List<BookModel>();
        }
    }
}