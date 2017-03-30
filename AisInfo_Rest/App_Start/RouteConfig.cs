using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace AisInfo_Rest
{
    public class RouteConfig
    {

        public static void RegisterRoutes(RouteCollection routes)
        {
            //routes.MapPageRoute(null, "", "~/Pages/Default.aspx");
            //routes.MapPageRoute(null, "Default", "~/Pages/Default.aspx");

            //routes.MapPageRoute(null, "ListDou", "~/Pages/ListDou.aspx");
            //routes.MapPageRoute(null, "ListEdv", "~/Pages/ListEdv.aspx");
            //routes.MapPageRoute(null, "ListStar", "~/Pages/ListStar.aspx");
            //routes.MapPageRoute(null, "ListEdvCh", "~/Pages/ListEDVchild.aspx");
            //routes.MapPageRoute(null, "PricePrint", "~/Pages/PrintPrice.aspx");
            //routes.MapPageRoute(null, "BaseKnow", "~/Pages/BaseKhow.aspx");
            //routes.MapPageRoute(null, "uchgor/{round}", "~/Pages/ListGorzhilservice.aspx");
            //routes.MapPageRoute(null, "uchgor", "~/Pages/ListGorzhilservice.aspx");


            //routes.MapPageRoute(null, "api", "~/Service/Service.svc");

            routes.MapPageRoute(null, "", "~/Default.aspx");




        }
    }
}