using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Vidly.Dto
{
    public class MovieDto
    {
        
        public int ID { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        public GenreDto Genre { get; set; }

        public DateTime CreatedDate { get; set; }
        
        [Required]
        public int GenreId { get; set; }

        [Range(1, 20)]
        public byte NumberInStock { get; set; }
    }
}