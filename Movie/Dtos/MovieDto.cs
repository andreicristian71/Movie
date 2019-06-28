using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Movie.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter movie's name.")]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public byte GenreId { get; set; }

        [Display(Name = "Number in stock")]
        [Range(1, 20, ErrorMessage = "The field Number in Stock must be between 1 and 20.")]
        public int NumberInStock { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }


    }
}