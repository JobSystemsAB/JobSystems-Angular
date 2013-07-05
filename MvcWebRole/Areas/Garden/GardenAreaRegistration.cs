using System.Web.Mvc;

namespace MvcWebRole.Areas.Garden
{
    public class GardenAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Garden";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Garden_default",
                "Garden/",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
