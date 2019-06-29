using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Movie.Models;
using System.Data.Entity;

namespace Movie.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult Index()
        {
            //var movies = _context.Movies.Include(c => c.Genre).ToList();
            //return View(movies);

            if (User.IsInRole(RoleName.CanManageMovies))
                return View("Index");
            return View("ReadOnlyIndex");
        }
        //[Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult New()
        {
            var genres = _context.Genres.ToList();
            var viewModel = new ViewModels.MovieFormViewModel()
            {
                Genres = genres
            };
            return View("MovieForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Models.Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new ViewModels.MovieFormViewModel(movie)
                {
                    Genres = _context.Genres.ToList()
                };
                return View("MovieForm", viewModel);
            }
            if (movie.Id == 0)
            {
                _context.Movies.Add(movie);

            }
            else
            {
                var movieInDb = _context.Movies.Single(c => c.Id == movie.Id);

                //Mapper.Map(movie,movieInDb);

                movieInDb.Name = movie.Name;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movie == null)
                return HttpNotFound();

            var viewModel = new ViewModels.MovieFormViewModel(movie)
            {
                Genres = _context.Genres.ToList()
            };
            return View("MovieForm", viewModel);


        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(c => c.Genre).SingleOrDefault(c => c.Id == id);
            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }

        //private IEnumerable<Models.Movie> GetMovies()
        //{
        //    return new List<Models.Movie>
        //    {
        //        new Models.Movie { Id = 1, Name = "Shrek" },
        //        new Models.Movie { Id = 2, Name = "Wall-e" }
        //    };
        //}

        // GET: Movies/Random
        //public ActionResult Random()
        //{
        //    var movie = new Models.Movie() { Name = "Shreck!" };
        //    var customers = new List<Customer>
        //    {
        //        new Customer { Name = "Customer 1" },
        //        new Customer { Name = "Customer 2" }
        //    };
        //    var viewModel = new ViewModels.RandomMovieViewModel
        //    {
        //        Movie = movie,
        //        Customers = customers
        //    };

        //    //ViewData["Movie"] = movie;
        //    //ViewBag.

        //    return View(viewModel);
        //}

        //public ActionResult Edit(int id)
        //{
        //    return Content("id=" + id);
        //}
        //movies
        //public ActionResult Index(int? pageIndex, string sortBy)
        //{
        //    if (!pageIndex.HasValue)
        //        pageIndex = 1;
        //    if (String.IsNullOrWhiteSpace(sortBy))
        //        sortBy = "Name";

        //    return Content(String.Format("pageIndex={0} & sortBy={1}", pageIndex, sortBy));
        //}

        //[Route("movies/released/{year:regex(\\d{2})}/{month:range(1,12)}")]
        //public ActionResult ByReleaseDate(int year, int month)
        //{
        //    return Content(year + " - " + month); 
        //}
    }
}