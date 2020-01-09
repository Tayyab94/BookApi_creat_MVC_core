using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPIs_Creation_MVCCore.Models
{
    public class BookAuthor
    {
        public int book_Id { get; set; }

        public Book Book { get; set; }

        public int author_Id { get; set; }

        public Author Author { get; set; }
    }
}
