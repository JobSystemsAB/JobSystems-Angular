using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcWebRole.Areas.MainPage.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /MainPage/Home/

        public ActionResult Index()
        {
            return View();
        }

    }
}
