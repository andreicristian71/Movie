using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Movie.Models;

namespace Movie.ViewModels
{
    public class RandomMovieViewModel
    {
        public Models.Movie Movie { get; set; }
        public List<Models.Customer> Customers { get; set; }
    }
}