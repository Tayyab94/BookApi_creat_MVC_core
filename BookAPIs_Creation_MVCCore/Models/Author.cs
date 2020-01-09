using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPIs_Creation_MVCCore.Models
{
    public class Author
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required][MaxLength(100,ErrorMessage ="First Name can not be more than 100 charactors.")]
        public string first_Name { get; set; }


        [Required]
        [MaxLength(200, ErrorMessage = "Last Name can not be more than 200 charactors.")]
        public string last_NameW { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<BookAuthor> BookAuthors { get; set; }

    }
}
