using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Movie.ViewModels
{
    public class MovieFormViewModel
    {
        public MovieFormViewModel()
        {
            this.Id = 0;
            this.NumberInStock = 1;
        }
        public MovieFormViewModel(Models.Movie movie)
        {
            this.Id = movie.Id;
            this.Name = movie.Name;
            this.NumberInStock = movie.NumberInStock;
            this.ReleaseDate = movie.ReleaseDate;
            this.GenreId = movie.GenreId;
        }

        public int? Id { get; set; }

        [Required(ErrorMessage = "Please enter movie's name.")]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public byte? GenreId { get; set; }

        [Display(Name = "Number in stock")]
        [Range(1, 20, ErrorMessage = "The field Number in Stock must be between 1 and 20.")]
        public int? NumberInStock { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }

        public IEnumerable<Models.Genre> Genres { get; set; }

        public string Title
        {
            get
            {
                if (this.Id != 0)
                    return "Edit Movie";
                return "New Movie";
            }
        }
    }
}