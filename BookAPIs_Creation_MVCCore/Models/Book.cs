using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPIs_Creation_MVCCore.Models
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required][MaxLength(200,ErrorMessage ="Title Can not be more than 200 charactors.")]
        public string title { get; set; }

        [Required]
        [StringLength(10,MinimumLength =3,ErrorMessage ="ISBN Muxt be between 3 to 30  charactors")]
        public string isbn { get; set; }

        public DateTime? date_Published { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }

        public virtual ICollection<BookAuthor> BookAuthors { get; set; }

        public virtual ICollection<BookCategory> BookCategories { get; set; }

    }
}
