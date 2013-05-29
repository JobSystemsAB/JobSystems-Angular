using System.Web.Mvc;

namespace MvcWebRole.Areas.MainPage
{
    public class MainPageAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "MainPage";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "MainPage_default",
                "MainPage/",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
