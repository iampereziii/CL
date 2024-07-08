using CL.Data.Context;
using CL.Domain.Models.Movies;
using CL.Domain.Movies.Dtos;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Security.Principal;

namespace CL.Service.Implementation
{
    public class MoviesService
    {
        CLContext _context;
        public MoviesService()
        {
            _context = new CLContext();
        }


        public Movie GetMovie(int id)
        {
            //get list
            List<Movie> movies = PopulateMovies().ToList();

            return movies.Where(x => x.Id == id).FirstOrDefault() ?? null;
        }

        public IEnumerable<Movie> GetMovie(string query)
        {
            List<Movie> movieList = new List<Movie>();

            if (!string.IsNullOrWhiteSpace(query))
            {
                List<Movie> movies = PopulateMovies().ToList();
                movieList = movies.FindAll(x => x.MovieName.ToLower().Contains(query.ToLower()));
            }

            if(movieList.Count > 0)
            {
                return movieList.FindAll(x => x.StocksAvailable > 0);
            }

            //get list

            return movieList;
        }

        public IEnumerable<Movie> GetMovies(int month, int year)
        {
            //get list
            List<Movie> movies = PopulateMovies().ToList();
            var selectedMovies = movies.Where(x => x.ReleasedDate.Value.Year == year && x.ReleasedDate.Value.Month == month);
            return selectedMovies.ToList();
        }

        public IEnumerable<Movie> PopulateMovies()
        {

            try
            {
                return _context.Movie.Include(x => x.Genre);
            }
            catch (System.Exception ex)
            {
                //Todo logging

                return null;

            }

        }

        public IEnumerable<Genre> GetGenres()
        {
            //eager loading 
            return _context.Genre;
        }

        //Create a response class 
        public int SaveMovies(Movie movie, string entity = "")
        {
            try
            {
                Genre genre = _context.Genre.Where(x => x.Id == movie.Genre.Id).FirstOrDefault();
                movie.Genre = genre;


                if (entity == "Create")
                {
                    movie.StocksAvailable = movie.Stocks; // add stocks
                    _context.Movie.Add(movie);
                }
                else
                {
                    //single because it's only a post, no need to handle null value
                    var movieContext = _context.Movie.Single(x => x.Id == movie.Id);

                    if (movie.Stocks > movieContext.Stocks) //if there is an addition
                    {
                        int stocksToAdd = movie.Stocks - movieContext.Stocks;
                        movieContext.StocksAvailable += stocksToAdd;
                    }
                    else
                    {
                        int stocksToLess = movieContext.Stocks - movie.Stocks;
                        movieContext.StocksAvailable -= stocksToLess;
                    }

                    movieContext.MovieName = movie.MovieName;
                    movieContext.ReleasedDate = movie.ReleasedDate;
                    movieContext.DateAdded = System.DateTime.Now;
                    movieContext.Stocks = movie.Stocks;
                    movieContext.Genre = movie.Genre;

                }
                _context.SaveChanges();
                return movie.Id;
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine(ex);
                return 0;
            }
        }
        //public bool SaveMovies(MovieDto Movie, string entity = "")
        //{
        //    try
        //    {
        //        //GenreModel genre = _context.Genre.Where(x => x.Id == Movie.Genre.Id).FirstOrDefault();
        //        //Movie.Genre = genre;

        //        if (entity == "Create")
        //        {
        //            _context.Movie.Add(Movie);
        //        }
        //        else
        //        {
        //            //single because it's only a post, no need to handle null value
        //            var movie = _context.Movie.Single(x => x.Id == Movie.Id);
        //            movie.MovieName = Movie.MovieName;
        //            movie.ReleasedDate = Movie.ReleasedDate;
        //            movie.DateAdded = System.DateTime.Now;
        //            movie.Stocks = Movie.Stocks;
        //        }

        //        return _context.SaveChanges() > 0 ? true : false;
        //    }
        //    catch (System.Exception ex)
        //    {
        //        throw;
        //    }
        //}


        public int DeleteMovie(Movie model)
        {
            try
            {
                _context.Movie.Remove(model);
            }
            catch (System.Exception)
            {

                throw;
            }
            return _context.SaveChanges();

        }
    }
}
