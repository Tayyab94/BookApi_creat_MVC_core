using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPIs_Creation_MVCCore.Models
{
    public class Review
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "Heandline Muxt be between 10 to 100  charactors")]
        public string headline { get; set; }

        [Required]
        [StringLength(2000, MinimumLength = 50, ErrorMessage = "Review-Text Muxt be between 10 to 100  charactors")]
        public string review_Text { get; set; }

        [Required]
        [Range(minimum: 1, maximum: 5, ErrorMessage = "Ratting must be between 1 to 5 stars")]
        public int rating { get; set; }

        public virtual Reviewer Reviewer { get; set; }

        public virtual Book Book { get; set; }
    }
}
