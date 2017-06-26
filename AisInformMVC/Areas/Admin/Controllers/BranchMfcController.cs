using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryService.Entities;
using LibraryService.Abstract;

namespace AisInformMVC.Areas.Admin.Controllers
{
  public class BranchMfcController : Controller
  {

    IBranchMfcWork Shed { get; set; }

    public BranchMfcController(IBranchMfcWork Sh)
    {
      Shed = Sh;
    }


    // GET: Admin/ShedOfWorkDiv
    public ActionResult Index()
    {
      var List = Shed.ListBranchMFC.ToList();
      
      return View(List);
    }
    [HttpPost]
    public ActionResult Edit(BranchMFC model)
    {
      if (ModelState.IsValid)
      {
        Shed.SaveBranchMfc(model);
        TempData["message"] = string.Format("Изменения в графике работы \"{0}\" были сохранены",model.NameMFC);
        //ViewBag.Head = "Редактирование";
        return RedirectToAction("Index");
      }
      else
      {
        return View(model);
      }
    }
    public ActionResult Edit(int id)
    {
      BranchMFC model = Shed.ListBranchMFC.FirstOrDefault(s => s.Id == id);

      return View(model);
    }

    public ViewResult Create()
    {
      return View("Edit", new BranchMFC(true));
    }

    public ActionResult Delete(int Id)
    {
      BranchMFC delete = Shed.DeleteBranchMfc(Id);
      if (delete != null)
      {
        TempData["message"] = string.Format("МФЦ : {0} был удален", delete.NameMFC);
      }
      return RedirectToAction("Index");
    }
  }
}