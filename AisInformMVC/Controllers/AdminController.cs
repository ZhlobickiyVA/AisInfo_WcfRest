using LibraryService;
using LibraryService.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AisInformMVC.Controllers
{
  //[Authorize]
  public class AdminController : Controller
  {
    // GET: Admin
    IAdRepository adrepository;

    public AdminController(IAdRepository adrepo)
    {
      adrepository = adrepo;
    }

    public ViewResult ListAds()
    {
      return View(adrepository.Ads);
    }

    public ViewResult EditAds(int Id)
    {
      Ad ad = adrepository.Ads.FirstOrDefault(a => a.Id == Id);
      return View(ad);

    }

    





    [HttpPost]
    public ActionResult EditAds(Ad ad)
    {
      
      if (ModelState.IsValid)
      {
        adrepository.SaveAd(ad);
        TempData["message"] = string.Format("Изменения в обьявлении \"{0}\" были сохранены", ad.Header);
        ViewBag.Head = "Редактирование";
        return RedirectToAction("ListAds");

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


    //[HttpPost]
    public ActionResult DeleteAd(int Id)
    {
      Ad deleteAd = adrepository.DeleteAd(Id);
      if (deleteAd != null)
      {
        TempData["message"] = string.Format("Обьявление c заголовков: {0} было удалено",deleteAd.Header);

      }
      return RedirectToAction("ListAds");
    }


  }
}