using System.Web.Mvc;

namespace MvcWebRole.Areas.PerformerPortal
{
    public class PerformerPortalAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "PerformerPortal";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "PerformerPortal_default",
                "PerformerPortal/",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
