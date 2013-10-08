using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace PageAndServices
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            #region JAVASCRIPT

            var libs = new ScriptBundle("~/bundle/libs");

            libs.Include("~/Scripts/JQuery/jquery-1.10.2.min.js");
            libs.Include("~/Scripts/JQuery/jquery-ui-1.10.3.custom.min.js");
            libs.Include("~/Scripts/JQuery/*.js");

            libs.Include("~/Scripts/Angular/angular.min.js");
            libs.Include("~/Scripts/Angular/*.js");

            libs.Include("~/Scripts/Angular-UI/ui-bootstrap-tpls-0.5.0.min.js");
            libs.Include("~/Scripts/Angular-UI/*.js");

            libs.Include("~/Scripts/Bootstrap/bootstrap.min.js");
            libs.Include("~/Scripts/Bootstrap/*.js");

            libs.Include("~/Scripts/underscore.js");
            libs.Include("~/Scripts/fullcalendar.min.js");
            libs.Include("~/Scripts/*.js");

            bundles.Add(libs);

            var app = new ScriptBundle("~/bundle/app");

            app.Include("~/Angular/Apps/*.js");
            app.Include("~/Angular/Filters/*.js");
            app.Include("~/Angular/Directives/*.js");
            app.Include("~/Angular/Services/*.js");
            app.Include("~/Angular/Controllers/*.js");

            bundles.Add(app);

            #endregion

            #region CSS

            var styles = new StyleBundle("~/bundle/css");
            styles.Include("~/Content/CSS/bootstrap.css");
            styles.Include("~/Content/CSS/bootstrap-theme.css");
            styles.Include("~/Content/CSS/*.css");

            bundles.Add(styles);

            #endregion


        }
    }
}