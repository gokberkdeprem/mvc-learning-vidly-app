using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        [Required]
        public int ID { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        
        [Required]
        public DateTime ReleaseDate { get; set; }
        
        public DateTime CreatedDate { get; set; }

        
        public Genre Genre { get; set; }
        [Required]
        [Display(Name=("Genre"))]
        public int GenreId { get; set; }

        [Range(1,20,ErrorMessage ="The field Number in Stock must be between 1 and 20")]
        public byte NumberInStock { get; set; }


    }
}