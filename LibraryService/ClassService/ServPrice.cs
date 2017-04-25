//using System;
//using System.Collections.Generic;
//using System.Collections.Specialized;
//using System.Configuration;
//using System.Data;
//using System.Data.SqlClient;
//using System.IO;
//using System.Linq;
//using System.ServiceModel;
//using System.Web;

//namespace LibraryService
//{
//  //[ServiceBehavior(InstanceContextMode =InstanceContextMode.Single)]
//  public class ServPrice : IServPrice
//  {



//    public string Connect()
//    {




//      return "Привет!!!!";

//    }

//    public ItemOgv[] GetListOgv()
//    {
//      //InstalConfigPDF.SerialiseData();


//      return new ModelPrice().GetListOgv();
//    }

//    public ItemDul[] GetListDul()
//    {
//      //InstalConfigPDF.SerListDul();
//      return new ModelPrice().GetListDul();
//    }

//    public void GetPriceDocument(string idOgv = "0", string idPur="0", string lname = "", string fname = "", string mname = "", string adress = "", string idtype = "", string numdul = "")
//    {


//      InfoPdf info = new InfoPdf()
//      {
//        IndexOrgan = idOgv,
//        IndexPurpose = idPur,
//        LastName = lname,
//        FirstName = fname,
//        MiddleName = mname,
//        PayerAdress = adress,
//        PayerIdType = idtype,
//        PayerIdNum = numdul
//      };





//      //Response.Clear();
//      //Response.ContentType = "application/pdf";
//      //Response.AddHeader("content-disposition", "inline;filename=" + "PriceDoc.pdf");
//      //Response.Cache.SetCacheability(HttpCacheability.NoCache);

//      //Response.BinaryWrite(Price.GetFile());
//      //Response.End();

//      //HttpContext.Current.Response.Clear();
//      HttpContext.Current.Response.ContentType = "application/pdf";
//      HttpContext.Current.Response.AddHeader("content-disposition", "inline;filename=Price.pdf");
//      HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);

//      //HttpContext.Current.Response.BinaryWrite(model.GetDocumentPrice(info));
//      //HttpContext.Current.Response.Write(String.Format("Орган {0} <br/> Тип платежа {1} < br />", info.indexOrgan, info.indexPurpose));
//      //HttpContext.Current.Response.Write(String.Format("Фамилия {0} <br/> Имя {1} <br/> Отчество {2} <br/> Адресс {3} <br/> ТипДокумента {4} <br/> Номер документа {5} <br/>"
//      //    , info.lastName, info.firstName, info.middleName,info.payerAdress,info.payerIdType,info.payerIdNum));

//      HttpContext.Current.Response.BinaryWrite(new ModelPrice().GetDocumentPrice(info));
//      //HttpContext.Current.Response.End();
//    }
//  }
//}