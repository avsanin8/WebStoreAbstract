using System.Web.Mvc;

namespace AreasApp.Areas.Store
{
    public class StoreAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Store";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Store_default",
                "Store/{controller}/{action}/{id}", //to Get ned //Store/Home/Index/params
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}