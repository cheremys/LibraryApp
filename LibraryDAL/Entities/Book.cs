using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryDAL.Entities
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        [MaxLength(50)]
        public string Author { get; set; }

        public DateTime? PublicationDate { get; set; }

        public string Description { get; set; }

        public int? CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
