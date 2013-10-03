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
            #region JAVASCRIPT

            #region JQUERY

            var jqueryBundle = new ScriptBundle("~/bundle/jquery/libs");
            jqueryBundle.Include("~/libs/jquery/jquery-1.10.2.min.js");
            jqueryBundle.Include("~/libs/jquery/jquery-ui-1.10.3.custom.min.js");

            bundles.Add(jqueryBundle);

            #endregion

            #region ANGULAR 

            var angularBundle = new ScriptBundle("~/bundle/angular/libs");
            angularBundle.Include("~/libs/angular/angular.min.js");
            angularBundle.Include("~/libs/angular/angular-resource.js");
            angularBundle.Include("~/libs/angular/angular-google-maps.js");
            
            bundles.Add(angularBundle);

            #endregion

            #region ANGULAR UI

            var angularUIBundle = new ScriptBundle("~/bundle/angular-ui/libs");
            angularUIBundle.Include("~/libs/angular-ui/angular-ui-router.js");            
            angularUIBundle.Include("~/libs/angular-ui/calendar.js");
            angularUIBundle.Include("~/libs/angular-ui/date.js");
            angularUIBundle.Include("~/libs/angular-ui/ui-bootstrap-tpls-0.5.0.min.js");

            bundles.Add(angularUIBundle);
            
            #endregion

            #region ANGULAR RESOURCES

            var angularResourcesBundle = new ScriptBundle("~/bundle/angular/resources");
            angularResourcesBundle.Include("~/assets/js/resources/*.js");
            angularResourcesBundle.Include("~/assets/js/resources/services/*.js");

            bundles.Add(angularResourcesBundle);

            #endregion

            #region ANGULAR GLOBAL

            var angularGlobalBundle = new ScriptBundle("~/bundle/angular/global");
            angularGlobalBundle.Include("~/assets/js/controllers/global/*.js");

            bundles.Add(angularGlobalBundle);

            #endregion

            #region JASMINE

            var jasmineBundle = new ScriptBundle("~/bundle/jasmine/libs");
            jasmineBundle.Include("~/libs/jasmine/jasmine.js");
            jasmineBundle.Include("~/libs/jasmine/jasmine-html.js");
            jasmineBundle.Include("~/libs/jasmine/angular-mocks.js");

            bundles.Add(jasmineBundle);

            #endregion

            #region JASMINE TESTS

            var jasmineTestsBundle = new ScriptBundle("~/bundle/jasmine/tests");
            jasmineTestsBundle.Include("~/Assets/js/tests/controllers/home/*.js");
            //jasmineTestsBundle.Include("~/Assets/js/tests/resources/*.js");

            bundles.Add(jasmineTestsBundle);

            #endregion

            #region BOOTSTRAP

            var bootstrapBundle = new ScriptBundle("~/bundle/bootrstrap/libs");
            bootstrapBundle.Include("~/libs/bootstrap/bootstrap.js");
            bootstrapBundle.Include("~/libs/bootstrap/collapse.js");
            bootstrapBundle.Include("~/libs/bootstrap/transition.js");

            bundles.Add(bootstrapBundle);

            #endregion

            #region OTHER

            var otherBundle = new ScriptBundle("~/bundle/libs");
            otherBundle.Include("~/libs/fullcalendar.min.js");
            otherBundle.Include("~/libs/gcal.js");
            otherBundle.Include("~/libs/underscore.js");
            otherBundle.Include("~/libs/underscore.string.js");

            bundles.Add(otherBundle);

            #endregion

            #region PAGES

            var pageHomeBundle = new ScriptBundle("~/bundle/pages/home");
            pageHomeBundle.Include("~/assets/js/apps/home.js");
            pageHomeBundle.Include("~/assets/js/controllers/home/*.js");
            pageHomeBundle.Include("~/assets/js/partials/partview/*.js");
            pageHomeBundle.Include("~/assets/js/partials/view/*.js");

            bundles.Add(pageHomeBundle);

            var pageAdminBundle = new ScriptBundle("~/bundle/pages/admin");
            pageAdminBundle.Include("~/assets/js/apps/admin.js");
            pageAdminBundle.Include("~/assets/js/controllers/admin/*.js");

            bundles.Add(pageAdminBundle);

            #endregion

            #endregion

            #region CSS

            #region GLOBAL CSS

            var cssGlobalBundle = new StyleBundle("~/bundle/css");
            cssGlobalBundle.Include("~/assets/css/main.css");
            cssGlobalBundle.Include("~/assets/css/normalize.css");
            cssGlobalBundle.Include("~/assets/css/jobsystems.css");
            cssGlobalBundle.Include("~/assets/css/bootstrap.css");
            cssGlobalBundle.Include("~/assets/css/bootstrap-theme.css");

            bundles.Add(cssGlobalBundle);

            #endregion

            #region ANGULAR UI CSS

            var cssAngularUIBundle = new StyleBundle("~/bundle/css/angular-ui");
            cssAngularUIBundle.Include("~/assets/css/fullcalendar.css");

            bundles.Add(cssAngularUIBundle);

            #endregion

            #region JASMINE CSS

            var cssJasmineBundle = new StyleBundle("~/bundle/css/jasmine");
            cssJasmineBundle.Include("~/assets/css/jasmine.css");

            bundles.Add(cssJasmineBundle);

            #endregion

            #endregion

            #region TESTS

            var testsBundle = new ScriptBundle("~/bundle/tests");
            testsBundle.Include("~/assets/js/tests/controllers/home/IndexSpec.js");

            bundles.Add(testsBundle);

            #endregion

        }
    }
}