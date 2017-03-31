using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace AisInfoService
{
  public class ServKnowBase : IServKnowBase
  {
    public string Connect()
    {
      //instalConfigPDF.SerListDul();
      //instalConfigPDF.DesListDul();
      //ListAreaGorZhilService.Serrial();
      return "Привет!!!!";
    }

    public void Posttest(Stream body)
    {
      string ret = new StreamReader(body).ReadToEnd();
      
      ret = HttpUtility.UrlDecode(ret);

      char[] masseparator = { '&' };
      

      string[] result = ret.Split(masseparator,StringSplitOptions.None);


      Dictionary<string, string> dic = new Dictionary<string, string>();


      for (int i = 0; i < result.Length; i++)
      {
        string[] item = result[i].Split('=');

        dic.Add(item[0].ToLower(),item[1]);
      }

      InfoPdf info = new InfoPdf();
      info.LastName = dic["lname"];
      info.FirstName = dic["fname"];
      info.MiddleName = dic["mname"];
      info.PayerAdress = dic["adress"];
      info.IndexOrgan = dic["ogv"];
      info.IndexPurpose = dic["purpose"];


      HttpContext.Current.Response.Write(info.LastName);
      HttpContext.Current.Response.Write(info.FirstName);
      HttpContext.Current.Response.Write(info.MiddleName);
      HttpContext.Current.Response.Write(info.PayerAdress);


      
    }
  }
}