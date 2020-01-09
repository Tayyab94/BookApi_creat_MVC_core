using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPIs_Creation_MVCCore.Models
{
    public class Country
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required]
        [MaxLength(50,ErrorMessage ="Country Name must be upto 50 Charactors.")]
        public string name { get; set; }

        public virtual ICollection<Author> Authors { get; set; }
    }
}
