using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MilliganNathaniel413Assignment3.Models
{
    public class Movie
    {
        [Key]
        public int MovieID { get; set; }

        //The “Edited”, “Lent To”, and “Notes” fields are optional. All other fields must be entered.
        [Required]
        public string Category { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public string Director { get; set; }
        [Required]
        public string Rating { get; set; }
        //bool? is nullable instead of bool which requires a true or false value
        public bool? Edited { get; set; }
        public string LentTo { get; set; }
        //limited Notes length on front end
        public string Notes { get; set; }

    }
}
