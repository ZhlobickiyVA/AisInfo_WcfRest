using Stimulsoft.Report;
using Stimulsoft.Report.Export;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AisInformMVC.Controllers
{
  public class StiController : Controller
  {
    // GET: Sti
    
      



    public FileResult Index()
    {
      


      StiReport report = new StiReport();
      StiPdfExportSettings setting = new StiPdfExportSettings();

      report.Load(Server.MapPath("/App_Data/Test.mrt"));

      MemoryStream ms = new MemoryStream();

      string file_type = "application/pdf";
      report.Render();
      report.ExportDocument(StiExportFormat.Pdf, ms);


      return File(ms.ToArray(), file_type);
    }


    public ActionResult Test()
    {

      return View();

    }

  }
}