using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AreasApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes(); //for use [Route("My/Account")] in Home/Index

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "AreasApp.Controllers" } // namespace AreasApp.Controllers in basic folder
            );

            //Route myRoute = new Route("{controller}/{action}", new MyRouteHandler());
            //routes.Add(myRoute);
        }

        //public class MyRouteHandler : IRouteHandler
        //{
        //    public IHttpHandler GetHttpHandler(RequestContext requestContext)
        //    {
        //        return new MyHttpHandler();
        //    }
        //}

        //public class MyHttpHandler : IHttpHandler
        //{
        //    public bool IsReusable => throw new NotImplementedException();

        //    public void ProcessRequest(HttpContext context)
        //    {
        //        context.Response.Write("<h2> worked - context.Response.Write </h2>");
        //    }
        //}
    }
}
