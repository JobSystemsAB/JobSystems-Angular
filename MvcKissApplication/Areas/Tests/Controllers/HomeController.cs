using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcKissApplication.Areas.Tests.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Tests/Home/

        public ActionResult Index()
        {
            return View();
        }

    }
}
