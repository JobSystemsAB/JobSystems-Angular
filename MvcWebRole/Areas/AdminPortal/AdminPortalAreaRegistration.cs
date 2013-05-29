using System.Web.Mvc;

namespace MvcWebRole.Areas.AdminPortal
{
    public class AdminPortalAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "AdminPortal";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "AdminPortal_default",
                "AdminPortal/",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
