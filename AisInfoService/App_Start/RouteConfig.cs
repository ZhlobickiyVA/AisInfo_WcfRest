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
      routes.MapPageRoute(null, "Default", "~/Pages/Default.aspx");
      //routes.MapPageRoute(null, "list", "~/Pages/Listing.aspx");
      //routes.MapPageRoute("List", "List", "~/ServList.svc");

      routes.MapPageRoute(null, "List", "~/Pages/ListForm.aspx");


      // Дополнительная информация
      routes.MapPageRoute(null, "ListGor", "~/Pages/Info/ListGorZhil.aspx");
      routes.MapPageRoute(null, "ListDous", "~/Pages/Info/ListDous.aspx");
      // Платежный документ
      routes.MapPageRoute(null, "PriceDoc", "~/Pages/PriceDoc/PriceDoc.aspx");
      // Список от СоцЦентра
      routes.MapPageRoute(null, "ListDou", "~/Pages/List/ListDou.aspx");
      routes.MapPageRoute(null, "ListEDV", "~/Pages/List/ListEDV.aspx");
      routes.MapPageRoute(null, "ListOldP", "~/Pages/List/ListOldP.aspx");
      routes.MapPageRoute(null, "ListEDMkinder", "~/Pages/List/ListEDMkinder.aspx");

      // База знаний
      routes.MapPageRoute(null, "KnowBase", "~/Pages/KnowBase/KnowBase.aspx");

      // Админинка
      routes.MapPageRoute(null, "Admin", "~/Pages/Admin/AdminService.aspx");
      routes.MapPageRoute(null, "Admin/EditService", "~/Pages/Admin/EditService.aspx");
    }
  }
}