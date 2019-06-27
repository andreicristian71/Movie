using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Movie.Models
{
    public class Genre
    {
        public byte Id { get; set; }
        [Required]
        [StringLength(64)]
        public string Name { get; set; }
    }
}