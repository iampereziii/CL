using CL.Domain.Dtos.Movies;
using CL.Domain.Models.Customers;
using CL.Domain.Models.Movies;
using CL.Domain.Movies.Dtos;
using CL.Service.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CL.Web.API
{
    public class CustomersController : ApiController
    {
        CustomersService customersService;
        public CustomersController()
        {
            customersService = new CustomersService();
        }
        public IHttpActionResult GetCustomer(string query)
        {
            List<Customer> customers = customersService.GetCustomerModel(query).ToList();
            if (customers.Count() > 0)
            {
                return Ok(customers.Select(AutoMapperService.Mapper.Map<Customer, CustomerDto>));
            }

            return NotFound();
        }
    }
}
