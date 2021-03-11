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
        
        public DateTime ReleaseDate { get; set; }
        
        public DateTime CreatedDate { get; set; }

        
        public Genre Genre { get; set; }
        [Required]
        [Display(Name=("Genre"))]
        public int GenreId { get; set; }


        public byte NumberInStock { get; set; }


    }
}