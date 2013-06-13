using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcWebRole.Areas.GardenPage.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /GardenPage/Home/

        public ActionResult Index()
        {
            return View();
        }

    }
}
