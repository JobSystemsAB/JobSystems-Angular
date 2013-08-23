using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace MvcKissApplication
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles) 
        {
            var libsBundle = new ScriptBundle("~/bundle/libs");
            libsBundle.Include("~/Libs/bootstrap.min.js");
            libsBundle.Include("~/Libs/ui-bootstrap-tpls-0.4.0.min.js");
            libsBundle.Include("~/Libs/angular-resource.js");
            libsBundle.Include("~/Libs/angular-google-maps.js");
            libsBundle.Include("~/Libs/date.js");
            libsBundle.Include("~/Libs/underscore.js");
            
            var angularScriptBundle = new ScriptBundle("~/bundle/angular/libs");
            angularScriptBundle.Include("~/Assets/js/resources/*.js");

            var HomeBundle = new ScriptBundle("~/bundle/pages/home");
            HomeBundle.Include("~/Assets/js/apps/home.js");
            HomeBundle.Include("~/Assets/js/controllers/home/*.js");

            var AdminBundle = new ScriptBundle("~/bundle/pages/admin");
            AdminBundle.Include("~/Assets/js/apps/admin.js");
            AdminBundle.Include("~/Assets/js/controllers/admin/*.js");


            //var cssBundle = new StyleBundle("~/bundle/css");
            //cssBundle.Include("~/Assets/css/bootstrap.min.css");
            //cssBundle.Include("~/Assets/css/page-global.css");

            bundles.Add(libsBundle);
            bundles.Add(angularScriptBundle);
            bundles.Add(HomeBundle);
            bundles.Add(AdminBundle);
        }
    }
}