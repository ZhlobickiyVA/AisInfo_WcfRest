using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Web;

namespace LibraryService
{

  public class ServKnowBase : IServKnowBase
  {
    public string Connect()
    {
      //instalConfigPDF.SerListDul();
      //instalConfigPDF.DesListDul();
      //ListAreaGorZhilService.Serrial();
      //new ModelKnowBase().GetData();
      return "Привет!!!!";
    }

    public ItemOgvKB[] GetDataBaseKnow()
    {
      return new ModelKnowBase().GetData();
    }

    public Stream GetImageOgv(string id)
    {
      return new ModelKnowBase().GetImageOgv(id);
    }


    //public void PostTest2(HttpContext context)
    //{
    //  context.Response.ContentType = "text/plain";

    //  // Чтение POST данных.
    //  string aParam = context.Request.Form["a"];
    //  string bParam = context.Request.Form["b"];

    //  // Формирование ответа.
    //  context.Response.Write("<b>POST</b> параметры переданные с запросом: a=" + aParam + ", b=" + bParam);
    //}


    public void Posttest(Stream body)
    {
      string ret = new StreamReader(body).ReadToEnd();

      ret = HttpUtility.UrlDecode(ret);

      var list = HttpUtility.ParseQueryString(ret);

      for (int i = 0; i < list.Count; i++)
      {
        HttpContext.Current.Response.Write(list.Keys[i] + " = " + list[list.Keys[i]] + "<br/>");
      }

    }

    public Stream TestImage()
    {
      string width = "400";
      string height = "400";


      if (!Int32.TryParse(width, out int w))
      {
        w = 640;
      }
      // Handle error
      if (!Int32.TryParse(height, out int h))
      {
        h = 400;
      }

      string Path = ConfigurationManager.AppSettings["TestPng"];
      string pathname = HttpContext.Current.Server.MapPath(Path);
      try
      {
        Bitmap bitmap = new Bitmap(pathname);
        MemoryStream ms = new MemoryStream();
        bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
        WebOperationContext.Current.OutgoingResponse.ContentType = "image/jpeg";
        return ms;
      }
      catch (Exception e)
      {
        HttpContext.Current.Response.Write(pathname + " Нет файла " + e.ToString());
        return null;

      }
    }


   

  }
}