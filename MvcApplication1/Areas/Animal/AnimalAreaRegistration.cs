using System.Web.Mvc;

namespace MvcApplication1.Areas.Animal
{
    public class AnimalAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Animal";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Animal_default",
                "Animal/",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
