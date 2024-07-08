using CL.Domain.Models.Movies;
using CL.Service.Implementation;
using CL.Service.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CL.Web.Controllers
{
    public class MoviesController : Controller
    {
        MoviesService moviesService;
        public MoviesController()
        {
            moviesService = new MoviesService();
        }
        // GET: Movies
        [Route("Movies")]
        public ActionResult Index()
        {
            if(User.IsInRole(Constants.Roles.CanEditMovie))
                return View("Index",moviesService.PopulateMovies());

            return View("ReadOnlyIndex",moviesService.PopulateMovies());

        }

        public ActionResult Details(int id)
        {
            var movie = moviesService.GetMovie(id);
            if (movie == null)
            {
                throw new HttpException(404, "NotFound"); // fix 
            }
            return View(movie);
        }

        [Route("movies/released/{year}/{month}")]
        public ActionResult MoviesByReleaseDate(int year, int month)
        {
            var movies = moviesService.GetMovies(month, year);
            if (movies == null)
            {
                throw new HttpException(404, "NotFound"); // fix 
            }
            return View("Index", movies);

        }

        public ActionResult New()
        {
            IEnumerable<Genre> genres = moviesService.GetGenres();
            MovieFormViewModel newMovie = new MovieFormViewModel()
            {
                Movie = new Movie(),
                GenreModel = genres
            };
            return View("MovieForm", newMovie);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie Movie) // parameter name must be the same with the propery name of the view
        {
            if (!ModelState.IsValid)
            {
                MovieFormViewModel newModel = new MovieFormViewModel()
                {
                    Movie = Movie,
                    GenreModel = moviesService.GetGenres(),
                    GenreId = Movie.Genre.Id
                };
                return View("MovieForm", newModel);
            }

            if (Movie.Id == 0)
            {
                moviesService.SaveMovies(Movie, "Create");
            }
            else
            {
                moviesService.SaveMovies(Movie, "Update");
            }


            return RedirectToAction("Index", "Movies");
        }

        [Authorize(Roles = Constants.Roles.CanEditMovie)]
        public ActionResult EditMovie(int id)
        {

            var movie = moviesService.GetMovie(id);
        
            IEnumerable<Genre> genres = moviesService.GetGenres();
            MovieFormViewModel newMovie = new MovieFormViewModel()
            {
                Movie = movie,
                GenreModel = genres,
                GenreId = movie.Genre.Id
            };
            return View("MovieForm", newMovie);

        }


    }
}