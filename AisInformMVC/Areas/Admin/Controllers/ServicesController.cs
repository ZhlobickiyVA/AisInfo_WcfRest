using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LibraryService;
using LibraryService.KhowBase;
using LibraryService.Abstract;

namespace AisInformMVC.Areas.Admin.Controllers
{
  public class ServicesController : Controller
  {
    private IKhowBase KnowBaseRepository;

    public ServicesController(IKhowBase knowbase)
    {
      KnowBaseRepository = knowbase;
    }




    // GET: Admin/Services
    public ActionResult Index()
    {
      var services = KnowBaseRepository.Services.ToList();
      return View(services);
    }


    // GET: Admin/Services/Create
    public ActionResult Create()
    {
      ViewBag.AuthorityId = new SelectList(KnowBaseRepository.Authoritys, "Id", "Name");
      ViewBag.CategoryId = new SelectList(KnowBaseRepository.Categorys, "Id", "Name");
      return View("Edit",new Service());
    }

    // GET: Admin/Services/Edit/5
    public ActionResult Edit(int id)
    {
      Service service = KnowBaseRepository.Services.FirstOrDefault(s => s.Id == id);
      ViewBag.AuthorityId = new SelectList(KnowBaseRepository.Authoritys, "Id", "Name", service.AuthorityId);
      ViewBag.CategoryId = new SelectList(KnowBaseRepository.Categorys, "Id", "Name", service.CategoryId);
      return View(service);
    }

    [HttpPost]
    [ValidateInput(false)]
    public ActionResult Edit(Service service)
    {
      
        KnowBaseRepository.SaveService(service);
        TempData["message"] = string.Format("Изменения в услуге \"{0}\" были сохранены", service.Name);
        return RedirectToAction("Index");
      
    }

    // GET: Admin/Services/Delete/5
    public ActionResult Delete(int id)
    {
      Service delete = KnowBaseRepository.DeleteService(id);
      if (delete != null)
      {
        TempData["message"] = string.Format("Услуга c именем: {0} удалено", delete.Name);
      }
      return RedirectToAction("Index");
    }

  }
}
