using CL.Domain.Models;
using CL.Domain.Models.Customers;
using CL.Domain.Models.Movies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.Domain.Dtos.Movies
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
