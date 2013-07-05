using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcWebRole.Areas.Garden.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Garden/Home/

        public ActionResult Index()
        {
            return View();
        }

    }
}
