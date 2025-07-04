using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementApp.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public required string Title { get; set; }
        public int YearPublished { get; set; }

        // Foreign key
        public int AuthorId { get; set; }

        // Navigation property
        public Author Author { get; set; } = null!;
    }
}
