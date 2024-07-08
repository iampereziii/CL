using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CL.Web.Views
{
    public class ErrorsController : Controller
    {
        // GET: Errors
        public ActionResult PageNotFound()
        {
            return View();
        }

    }
}