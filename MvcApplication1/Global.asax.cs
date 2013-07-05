using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MvcApplication1
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            var bootstrapOrdering = new BundleFileSetOrdering("animal");
            bootstrapOrdering.Files.Add("animal.js");
            bootstrapOrdering.Files.Add("index.js");
            bootstrapOrdering.Files.Add("employee-application.js");

            BundleTable.Bundles.FileSetOrderList.Add(bootstrapOrdering);

            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}