
using System;
using System.ComponentModel.DataAnnotations;

namespace Movie.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public Genre Genre { get; set; }

        [Display(Name = "Genre")]
        [Required]
        public byte GenreId { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Number in stock")]
        [Range(1, 20, ErrorMessage = "The field Number in Stock must be between 1 and 20.")]
        public int NumberInStock { get; set; }

        public int NumberAvailable { get; set; }

    }
}