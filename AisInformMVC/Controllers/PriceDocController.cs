using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryService.Price;
using LibraryService.Abstract;
using LibraryService;
using AisInformMVC.Models;
using System.Data.Entity;

namespace AisInformMVC.Controllers
{
  public class PriceDocController : Controller
  {
    private IPriceDocument PriceDocRepository;

    public PriceDocController(IPriceDocument price)
    {
      PriceDocRepository = price;
    }


    public ActionResult GetData()
    {
      IEnumerable<AuthoryPrice> listogv = PriceDocRepository.AuthoryPrices.ToList();
      foreach (var item in listogv)
      {
        item.Purposes = PriceDocRepository.Purposes.Where(s=>s.AuthoryPriceId==item.Id).ToList();
      }
      return Json(listogv, JsonRequestBehavior.AllowGet);
    }

    public ActionResult GetDataDocument()
    {
      var list = PriceDocRepository.Documents.ToList();
      return Json(list, JsonRequestBehavior.AllowGet);
    }

    public ActionResult Index()
    {
      
      return View();
    }


    [HttpPost]
    public FileResult Index(PriceViewModel model)
    {
      byte[] file = null;
      string file_type = "application/pdf";

      file = new FormationDocumentPrice(model).GetDocumentPrice();

      return File(file, file_type);
    }


  }
}