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
            libsBundle.Include("~/Libs/angular-resource.js");
            libsBundle.Include("~/Libs/ui-bootstrap-tpls-0.3.0.min.js");
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
            
            var animalStyleBundle = new StyleBundle("~/bundle/animal/css");
            cssBundle.Include("~/Assets/css/page-animal.css");

            bundles.Add(libsBundle);
            bundles.Add(cssBundle);
            bundles.Add(angularScriptBundle);
            bundles.Add(animalScriptBundle);
            bundles.Add(animalStyleBundle);
        }
    }
}