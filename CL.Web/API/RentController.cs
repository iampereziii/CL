using CL.Domain.Dtos.Movies;
using CL.Service.Implementation;
using CL.Service.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CL.Web.API
{
    public class RentController : ApiController
    {
        RentService rentService;
        public RentController()
        {
            rentService = new RentService();
        }
        // GET: api/Rent
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Rent/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Rent
        public IHttpActionResult Post(RentDto rentDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

             int rentSatus = rentService.RentMovie(rentDto.CustomerId, rentDto.MovieId);

            if (rentSatus == Constants.INVALID_USER || rentSatus == Constants.INVALID_MOVIE)
            {
                return BadRequest("Check the customer or movide Ids");
            }

            if (rentSatus == Constants.MOVIE_NOT_AVAILABLE)
            {
                return BadRequest("Movie not available");
            }
                
            return Ok(new { status = "ok" });
        }

        // PUT: api/Rent/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Rent/5
        public void Delete(int id)
        {
        }
    }
}
