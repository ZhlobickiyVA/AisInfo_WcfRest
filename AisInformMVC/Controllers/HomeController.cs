using AisInformMVC.Models;
using LibraryService;
using LibraryService.Abstract;
using LibraryService.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;


namespace AisInformMVC.Controllers
{
  public class HomeController : Controller
  {
    
    

    private IAdRepository AdRepository;
    private IEmployeesRepository EmplRepository;
    private IHoliDayRepository HoliRepository;
    private IDictionaryList Diclist;

    public int pageSize = 6;

    public HomeController(IAdRepository adrepo,IEmployeesRepository EmplRepo,IHoliDayRepository HoliRepo,IDictionaryList Dlist)
    {
      AdRepository = adrepo;
      EmplRepository = EmplRepo;
      HoliRepository = HoliRepo;
      Diclist = Dlist;
      
    }

    public ActionResult DetailsAds(int Id)
    {
      Ad ad = AdRepository.Ads.FirstOrDefault(a => a.Id == Id);
      if (ad != null)
      {
        return View(ad);
      }
      return HttpNotFound();

    }

    [HttpPost]
    public ActionResult EditAds(Ad ad)
    {

      if (ModelState.IsValid)
      {
        AdRepository.SaveAd(ad);
        TempData["message"] = string.Format("Обьявление сохранено", ad.Header);
        ViewBag.Head = "Редактирование";
        return RedirectToAction("Index");
      }
      else
      {
        return View(ad);
      }
    }
    public ViewResult CreateAd()
    {
      ViewBag.Head = "Новое обьявление";
      return View("EditAds", new Ad());
    }



    public ActionResult Index(int page = 1)
    {
      ViewBag.Message = "Доброе утро";
      ViewBag.InfoMessage = "Привет";

      DateTime Now = DateTime.Now.Date;
      string st = Diclist.DictionaryList.Where(s => s.Type == TypeDictionary.Weather).Select(s=>s.Value).FirstOrDefault();

      RootObject wea = null;

      try
      {
        wea = JsonConvert.DeserializeObject<RootObject>(st);
        wea.current_observation.wind_dir = Util.windDirect(wea.current_observation.wind_dir);
        wea.current_observation.pressure_mb = Util.ConvertGpaToMmHgSt(wea.current_observation.pressure_mb);
      }
      catch {     
      }



      AisViewInfo model = new AisViewInfo
      {
        Ads = AdRepository.Ads.ToList()
        .OrderBy(ad => ad.TheValidity)
        .Skip((page - 1) * pageSize)
        .Take(pageSize),

        PagingInfo = new PagingInfo
        {
          CurrentPage = page,
          ItemsPerPage = pageSize,
          TotalItems = AdRepository.Ads.Count()
        },

        Employees = EmplRepository.Staff.ToList().OrderBy(s => s.DateOfBirth)
        .Where(e => e.DateOfBirth.Date.Month == Now.Date.Month)
        ,


        Holiday = HoliRepository.Holidays.ToList().OrderBy(s => s.Date)
        .Where(e => e.Date.Date.Month == Now.Date.Month
        && e.Date.Date.Day == Now.Date.Day),

        Weather = wea
      

        


      };
      ViewBag.Month = DateTimeFormatInfo.CurrentInfo.MonthNames[DateTime.Now.Month-1];

      // --------------------

      return View(model);

    }


  }
}