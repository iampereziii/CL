using CL.Domain.Models.Customers;
using CL.Domain.Models.Movies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.Domain.Dtos.Movies
{
    public class RentDto
    {
        public int CustomerId { get; set; }
        public List<int> MovieId { get; set; }
    }
}
