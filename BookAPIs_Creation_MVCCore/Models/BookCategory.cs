using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPIs_Creation_MVCCore.Models
{
    public class BookCategory
    {
        public int book_Id { get; set; }

        public Book Book { get; set; }

        public int category_Id { get; set; }

        public Category Category { get; set; }
    }
}
