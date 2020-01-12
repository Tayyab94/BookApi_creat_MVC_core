using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPIs_Creation_MVCCore.DTO
{
    public class ReviewDTO
    {
        public int Id { get; set; }
        public string HeadLine { get; set; }

        public string ReviewTest { get; set; }

        public int Rating { get; set; }
    }
}
