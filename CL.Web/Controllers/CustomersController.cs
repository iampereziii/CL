using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CL.Domain.Models.Customers;
using CL.Service.Implementation;
namespace CL.Web.Controllers
{
    public class CustomersController : Controller
    {
       
        CustomersService customerService;
        public CustomersController()
        {
            customerService = new CustomersService();
        }
        // GET: Customers
        [Route("Customers")]
        public ActionResult Index()
        {

            //Customers customer = new Customers { }
            return View(customerService.GetCustomerModel());
        }
    
        public ActionResult Details(int id)
        {
            var customer = customerService.GetCustomerModel(id);
            if (customer == null) {
                   throw new HttpException(404, "NotFound"); // fix 
            }
            return View(customer);
        }

    }
}