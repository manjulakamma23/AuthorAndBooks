using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementApp.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }

        // Navigation property
        public List<Book> Books { get; set; }= new List<Book>();
    }
}
