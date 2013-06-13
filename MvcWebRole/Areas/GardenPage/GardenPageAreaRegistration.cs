using System.Web.Mvc;

namespace MvcWebRole.Areas.GardenPage
{
    public class GardenPageAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "GardenPage";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "GardenPage_default",
                "GardenPage/",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
