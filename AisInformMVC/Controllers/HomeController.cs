using AisInformMVC.Models;
using LibraryService;
using LibraryService.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace AisInformMVC.Controllers
{
  public class HomeController : Controller
  {
    
    

    private IAdRepository AdRepository;
    private IEmployeesRepository EmplRepository;
    private IHoliDayRepository HoliRepository;

    public int pageSize = 6;

    public HomeController(IAdRepository adrepo,IEmployeesRepository EmplRepo,IHoliDayRepository HoliRepo)
    {
      AdRepository = adrepo;
      EmplRepository = EmplRepo;
      HoliRepository = HoliRepo;
      
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


    public ActionResult Index(int page = 1)
    {
      ViewBag.Message = "Доброе утро";
      ViewBag.InfoMessage = "Привет";

      DateTime Now = DateTime.Now.Date;

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

        Employees = EmplRepository.Staff.ToList()
        .Where(e=> e.DateOfBirth.Date.Month == Now.Date.Month 
        && e.DateOfBirth.Date.Day == Now.Date.Day),


        Holiday = HoliRepository.Holidays.ToList()
        .Where(e => e.Date.Date.Month == Now.Date.Month
        && e.Date.Date.Day == Now.Date.Day)


      };

      
      return View(model);

    }


  }
}