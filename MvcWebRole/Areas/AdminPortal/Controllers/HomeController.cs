using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcWebRole.Areas.AdminPortal.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /AdminPortal/Home/

        public ActionResult Index()
        {
            return View();
        }

    }
}
