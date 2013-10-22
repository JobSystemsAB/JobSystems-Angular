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

            libs.Include("~/Scripts/Tinymce/tinymce.min.js");

            libs.Include("~/Scripts/Angular/angular.min.js");
            libs.Include("~/Scripts/Angular/angular-google-maps.js");
            libs.Include("~/Scripts/Angular/angular-resource.js");

            libs.Include("~/Scripts/Angular-UI/ui-bootstrap-tpls-0.6.0.js");
            libs.Include("~/Scripts/Angular-UI/angular-ui-router.js");
            libs.Include("~/Scripts/Angular-UI/calendar.js");
            libs.Include("~/Scripts/Angular-UI/date.js");
            libs.Include("~/Scripts/Angular-UI/tinymce.js");
            libs.Include("~/Scripts/Angular-UI/ng-grid-2.0.7.min.js");

            libs.Include("~/Scripts/Bootstrap/bootstrap.min.js");
            libs.Include("~/Scripts/Bootstrap/collapse.js");
            libs.Include("~/Scripts/Bootstrap/transition.js");

            libs.Include("~/Scripts/underscore.js");
            libs.Include("~/Scripts/underscore.string.js");
            libs.Include("~/Scripts/fullcalendar.min.js");
            libs.Include("~/Scripts/gcal.js");

            bundles.Add(libs);

            var app = new ScriptBundle("~/bundle/app");

            app.Include("~/Angular/Apps/HomeApp.js");

            app.Include("~/Angular/Directives/CompileDirective.js");
            app.Include("~/Angular/Directives/ContentEditableDirective.js");
            app.Include("~/Angular/Directives/GooglePlace.js");
            app.Include("~/Angular/Directives/OnBlurDirective.js");
            app.Include("~/Angular/Directives/OnFocusDirective.js");

            app.Include("~/Angular/Services/AdministratorService.js");
            app.Include("~/Angular/Services/AlertService.js");
            app.Include("~/Angular/Services/Base64Service.js");
            app.Include("~/Angular/Services/CategoryService.js");
            app.Include("~/Angular/Services/CategoryInputService.js");
            app.Include("~/Angular/Services/CompanyCustomerService.js");
            app.Include("~/Angular/Services/CustomerService.js");
            app.Include("~/Angular/Services/EmployeeService.js");
            app.Include("~/Angular/Services/GoogleMapsService.js");
            app.Include("~/Angular/Services/MissionService.js");
            app.Include("~/Angular/Services/PrivateCustomerService.js");
            app.Include("~/Angular/Services/TestimonialService.js");
            app.Include("~/Angular/Services/TextMessageService.js");
            app.Include("~/Angular/Services/TextService.js");
            app.Include("~/Angular/Services/ValidationService.js");
            app.Include("~/Angular/Services/WorkShiftService.js");

            app.Include("~/Angular/Controllers/Admin/ServicesController.js");
            app.Include("~/Angular/Controllers/Admin/EmployeesController.js");
            app.Include("~/Angular/Controllers/Admin/TestimonialsController.js");
            app.Include("~/Angular/Controllers/Admin/TextsController.js");
            app.Include("~/Angular/Controllers/Admin/LoginController.js");
            app.Include("~/Angular/Controllers/Admin/ServiceInputsController.js");
            app.Include("~/Angular/Controllers/Partials/AlertController.js");
            app.Include("~/Angular/Controllers/Partials/FooterController.js");
            app.Include("~/Angular/Controllers/Home/ApplicationController.js");
            app.Include("~/Angular/Controllers/Home/BookingController.js");
            app.Include("~/Angular/Controllers/Home/IndexBodyController.js");
            app.Include("~/Angular/Controllers/Home/LandingController.js");

            bundles.Add(app);

            #endregion

            #region CSS

            var styles = new StyleBundle("~/bundle/css");
            styles.Include("~/Content/CSS/bootstrap.css");
            styles.Include("~/Content/CSS/bootstrap-theme.css");
            styles.Include("~/Content/CSS/fullcalendar.css");
            styles.Include("~/Content/CSS/ng-grid.css");

            styles.Include("~/Content/CSS/theme1.css");
            //styles.Include("~/Content/CSS/theme2.css");

            bundles.Add(styles);

            #endregion


        }
    }
}