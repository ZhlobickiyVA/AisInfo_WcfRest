using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace AisInfoService
{
  public class RouteConfig
  {
    public static void RegisterRoutes(RouteCollection routes)
    {
      routes.MapPageRoute(null, "", "~/Pages/Default.aspx");
      //routes.MapPageRoute(null, "list", "~/Pages/Listing.aspx");
      routes.MapPageRoute("List", "List", "~/ServList.svc");
    }
  }
}