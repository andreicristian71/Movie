using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Movie.ViewModels
{
    public class MovieFormViewModel
    {
        public Models.Movie Movie { get; set; }
        public IEnumerable<Models.Genre> Genres { get; set; }
    }
}