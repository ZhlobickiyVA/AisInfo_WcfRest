using LibraryService;
using LibraryService.Abstract;
using LibraryService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AisInformMVC.Controllers
{
  public class InfoController : Controller
  {
    // GET: Info
    private IDictionaryList Diclist;

    public InfoController(IDictionaryList dict)
    {
      Diclist = dict;
    }

    public ActionResult Index()
    {
      return View();
    }
    // Участки Гор ЖилСервис
    public ActionResult AreasGorZhilServic()
    {
      return View();
    }
    // Список ДОУ
    public ActionResult ListKindergarten()
    {
      return View();
    }
    // Производственный календарь
    public ActionResult ProductionCalendar(int Year = 0)
    {
      string st = Diclist.DictionaryList.Where(s => s.Type == TypeDictionary.ProductionCalendar).Select(s => s.Value).FirstOrDefault();
      IEnumerable<ProzCalendarData> data =  ProzCalendarData.ConvertJsonToObject(st);
      
      int ye = 0;
      if (Year == 0) ye = DateTime.Now.Year;
      else ye = Year;

      ProzCalendarData DataYear = data.Where(s => s.YearMonth == ye.ToString()).FirstOrDefault();
      
      List <int[,]> List = ProzCalendarData.GetTableCalendar(DataYear);

      ViewBag.ListYear = data.Select(s => s.YearMonth).ToArray();
      ViewBag.YearMonth = DataYear.YearMonth;
      ViewBag.SumHepyDay = DataYear.SumHepyDay;
      ViewBag.SumWork24Hour = DataYear.SumWork24Hour;
      ViewBag.SumWork36Hour = DataYear.SumWork36Hour;
      ViewBag.SumWork40Hour = DataYear.SumWork40Hour;
      ViewBag.SumWorkDay = DataYear.SumWorkDay;

      return View(List);
    }



    
    
    

  }
}