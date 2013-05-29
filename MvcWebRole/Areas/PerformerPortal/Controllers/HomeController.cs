using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcWebRole.Areas.PerformerPortal.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /PerformerPortal/Home/

        public ActionResult Index()
        {
            return View();
        }

    }
}
