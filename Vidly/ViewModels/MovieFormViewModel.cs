using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Vidly.Models;
namespace Vidly.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }


        public int? ID { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        [Display(Name = ("Genre"))]
        public int? GenreId { get; set; }

        [Range(1, 20, ErrorMessage = "The field Number in Stock must be between 1 and 20")]
        [Required]
        public byte? NumberInStock { get; set; }

        public string Title
        {

            get
            {
                return ID != 0 ? "Edit Movie" : "New Movie";
            }
        }

        public MovieFormViewModel()
        {
            ID = 0;// To make sure the hidden field is populated 
        }
        public MovieFormViewModel(Movie movie)
        {
            ID = movie.ID;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            NumberInStock = movie.NumberInStock;
            GenreId = movie.GenreId;
        }

    }
}