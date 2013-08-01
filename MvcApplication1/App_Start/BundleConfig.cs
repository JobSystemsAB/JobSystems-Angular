using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace MvcApplication1
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles) 
        {
            var libsBundle = new ScriptBundle("~/bundle/libs");
            libsBundle.Include("~/Libs/bootstrap.min.js");
            libsBundle.Include("~/Libs/ui-bootstrap-tpls-0.4.0.min.js");
            libsBundle.Include("~/Libs/angular-resource.js");
            libsBundle.Include("~/Libs/date.js");
            libsBundle.Include("~/Libs/underscore.js");
            
            var cssBundle = new StyleBundle("~/bundle/css");
            cssBundle.Include("~/Assets/css/bootstrap.min.css");
            cssBundle.Include("~/Assets/css/page-global.css");
            
            var angularScriptBundle = new ScriptBundle("~/bundle/angular/libs");
            angularScriptBundle.Include("~/Assets/js/resources/resources.js");

            var animalScriptBundle = new ScriptBundle("~/bundle/animal/libs");
            animalScriptBundle.Include("~/Assets/js/apps/animal.js");
            animalScriptBundle.Include("~/Assets/js/controllers/animal/index.js");
            animalScriptBundle.Include("~/Assets/js/controllers/animal/employee-application.js");

            var adminScriptBundle = new ScriptBundle("~/bundle/admin/libs");
            adminScriptBundle.Include("~/Assets/js/apps/admin.js");
            adminScriptBundle.Include("~/Assets/js/controllers/admin/approve-employee.js");

            var animalStyleBundle = new StyleBundle("~/bundle/animal/css");
            animalStyleBundle.Include("~/Assets/css/page-animal.css");

            var adminStyleBundle = new StyleBundle("~/bundle/admin/css");
            adminStyleBundle.Include("~/Assets/css/page-admin.css");


            bundles.Add(libsBundle);
            bundles.Add(cssBundle);
            bundles.Add(angularScriptBundle);

            bundles.Add(animalScriptBundle);
            bundles.Add(adminScriptBundle);

            bundles.Add(animalStyleBundle);
            bundles.Add(adminStyleBundle);
        }
    }
}