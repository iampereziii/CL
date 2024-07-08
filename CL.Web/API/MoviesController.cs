using CL.Domain.Models.Movies;
using CL.Domain.Movies.Dtos;
using CL.Service.Implementation;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CL.Web.API
{
    public class MoviesController : ApiController
    {
        MoviesService movieService;


        public MoviesController()
        {
            movieService = new MoviesService();
        }
        // GET api/<controller>
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<controller>/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<controller>
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<controller>/5
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<controller>/5
        //public void Delete(int id)
        //{ 
        //}


        public IHttpActionResult GetMovies()
        {
            // return movieService.PopulateMovies();
            return Ok(movieService.PopulateMovies().ToList().Select(AutoMapperService.Mapper.Map<Movie, MovieDto>));


        }

        public IHttpActionResult GetMovies(int id)
        {
            var movie = movieService.GetMovie(id);

            if (movie != null)
            {
                return Ok(AutoMapperService.Mapper.Map<Movie, MovieDto>(movie));
            }

            return NotFound();

        }
        public IHttpActionResult GetMovies(string query)
        {
            var movie = movieService.GetMovie(query);

            if (movie != null)
            {
                return Ok(movie.Select(AutoMapperService.Mapper.Map<Movie, MovieDto>));

            }

            return NotFound();

        }

        [Authorize(Roles = Service.Utility.Constants.Roles.CanEditMovie)]
        public IHttpActionResult PostMovie(MovieDto movieDto)
        {
            //201 created 
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            Movie Movie = AutoMapperService.Mapper.Map<MovieDto, Movie>(movieDto);

            if (!movieService.SaveMovies(Movie, "Create").Equals(0))
            {
                return Created(new Uri(Request.RequestUri.ToString() + "/" + Movie.Id), movieDto);
            }
            else
            {
                return BadRequest();
            }

        }

        [Authorize(Roles = Service.Utility.Constants.Roles.CanEditMovie)]
        [HttpPut]
        public IHttpActionResult UpdateMovie(int id, MovieDto movieDto)
        {

            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            Movie Movie = AutoMapperService.Mapper.Map<MovieDto, Movie>(movieDto);
            Movie.Id = id;
            if (!movieService.SaveMovies(Movie).Equals(0))
                return Ok(new { status = "ok" });
            // return Request.CreateResponse(HttpStatusCode.OK, new { status = "ok" });
            return NotFound();
            //return Request.CreateResponse(HttpStatusCode.NotFound, new { status = "profile not updated" });
        }

        [Authorize(Roles = Service.Utility.Constants.Roles.CanEditMovie)]
        public IHttpActionResult DeleteMovie(int id)
        {
            HttpResponseMessage httpResponse = Request.CreateErrorResponse(HttpStatusCode.NotFound, "Data not deleted");

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var movie = movieService.GetMovie(id);
            if (movie != null)
            {
                if (movieService.DeleteMovie(movie) > 0)
                {
                    return Ok();
                }
            }

            return NotFound(); 
        }
    }
}
