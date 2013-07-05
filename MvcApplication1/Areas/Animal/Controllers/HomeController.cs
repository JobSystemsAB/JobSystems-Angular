using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication1.Areas.Animal.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Animal

        public ActionResult Index()
        {
            return View();
        }

    }
}
