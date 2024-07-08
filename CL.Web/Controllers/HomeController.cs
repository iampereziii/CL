using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CL.Web.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            
            TestModel model = new TestModel { ModelName = "New Model" };

            var viewResult = new ViewResult();
            viewResult.ViewData.Model = model;
            var checker = viewResult.Model;
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
           
            return View();
        }
    }


    public class TestModel
    {

        public string ModelName { get; set; }
    }
}