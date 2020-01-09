using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPIs_Creation_MVCCore.Models
{
    public class Reviewer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int id { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "Country Name must be upto 100 Charactors.")]

        public string first_Name { get; set; }
        [Required]
        [MaxLength(200, ErrorMessage = "Country Name must be upto 200 Charactors.")]

        public string last_NameW { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
    }
}
