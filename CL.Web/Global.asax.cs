using CL.Service.Implementation;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace CL.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        //public static IMapper Mapper { get; set; }

        protected void Application_Start()
        {

            //var mapperConfiguration =   
            //Mapper = mapperConfiguration.CreateMapper();
            AutoMapperService.Map();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
