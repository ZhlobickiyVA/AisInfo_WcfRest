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
    IEmployeesRepository emplrepository;


    public AdminController(IAdRepository adrepo,IEmployeesRepository emprepo)
    {
      adrepository = adrepo;
      emplrepository = emprepo;
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

    
    ///  Сотрудники

    public ViewResult ListEmployees()
    {
      return View(emplrepository.Staff.OrderBy(s=>s.LastName));
    }

    public ViewResult EditEmployees(int Id)
    {
      
      Employee empl = emplrepository.Staff.FirstOrDefault(a => a.Id == Id);
      ViewBag.Head = "Редактирование/Создание сотрудника";
      return View(empl);
    }

    [HttpPost]
    public ActionResult EditEmployees(Employee Empl)
    {

      if (ModelState.IsValid)
      {
        emplrepository.SaveEmpl(Empl);
        TempData["message"] = string.Format("Изменения в сотруднике \"{0}\" были сохранены", Empl.GetShortName());
        ViewBag.Head = "Редактирование";
        return RedirectToAction("ListEmployees");
      }
      else
      {
        return View(Empl);
      }
    }
    public ViewResult CreateEmployees()
    {
      ViewBag.Head = "Новый сотрудник";
      return View("EditEmployees", new Employee());
    }

    public ActionResult DeleteEmployees(int Id)
    {
      Employee deleteEmpl = emplrepository.DeleteEmpl(Id);
      if (deleteEmpl != null)
      {
        TempData["message"] = string.Format("Сотрудник : {0} был удалено", deleteEmpl.GetShortName());
      }
      return RedirectToAction("ListEmployees");
    }


  }
}