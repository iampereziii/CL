using CL.Data.Context;
using CL.Domain.Models.Movies;
using CL.Domain.Models.Rents;
using CL.Service.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.Service.Implementation
{
    public class RentService
    {
        CLContext _context;
        MoviesService movieService;




        public RentService()
        {
            _context = new CLContext();
            movieService = new MoviesService();
        }

        public int RentMovie(int customerId, List<int> movieIds)
        {
            List<string> errorRental = new List<string>();

            List<Rental> rentals = new List<Rental>();
            try
            {
                var customer = _context.Customer.Where(x => x.Id.Equals(customerId)).SingleOrDefault();

                if (customer == null)
                    return Constants.INVALID_USER;

                foreach (int id in movieIds)
                {
                    Movie movie = _context.Movie.Where(x => x.Id.Equals(id)).SingleOrDefault();
                    if (movie != null)
                    {
                        if (IsMovieAvailable(movie.StocksAvailable))
                        {
                            movie.StocksAvailable--;
                            movieService.SaveMovies(movie);

                            Rental rental = new Rental()
                            {
                                Movie = movie,
                                Customer = customer,
                                DateRented = DateTime.Now,
                            };

                            rentals.Add(rental);
                        }
                        else
                        {
                            return Constants.MOVIE_NOT_AVAILABLE;
                        }
                    }
                    else
                    {
                        return Constants.INVALID_MOVIE;
                    }
                }


                {
                    _context.Rental.AddRange(rentals);
                    _context.SaveChanges();
                }
            }
            catch (Exception)
            {

                return Constants.INVALID_USER;
            }
            return 0;

        }

        public bool IsMovieAvailable(int availability)
        {
            if (availability > 0)
                return true;

            return false;
        }
    }
}
