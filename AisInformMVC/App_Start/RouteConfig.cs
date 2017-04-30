using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AisInformMVC
{
  public class RouteConfig
  {
    public static void RegisterRoutes(RouteCollection routes)
    {
      routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

     

      routes.MapRoute(
          name: "Default",
          url: "{controller}/{action}",
          defaults: new { controller = "Home", action = "Index"},
          namespaces: new[] { "AisInformMVC.Controllers" }
      );

      routes.MapRoute(
          name: "ListDou",
          url: "{controller}/{action}",
          defaults: new { controller = "ListSoc", action = "ListDOU"}
      );

      routes.MapRoute(
          name: "ListEdv",
          url: "{controller}/{action}",
          defaults: new { controller = "ListSoc", action = "ListEDV"}
      );

      routes.MapRoute(
          name: "ListOldPeople",
          url: "{controller}/{action}",
          defaults: new { controller = "ListSoc", action = "ListOldPeople" }
      );

      routes.MapRoute(
          name: "ListPayKinder",
          url: "{controller}/{action}",
          defaults: new { controller = "ListSoc", action = "ListPayKinder" }
      );



    }
  }
}
