using System.Web.Mvc;

namespace MvcWebRole.Areas.Performer
{
    public class PerformerAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Performer";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Performer_default",
                "Performer/",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
