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
  


  public class AuthoritiesController : Controller
  {
    private IKhowBase KnowBaseRepository;

    public AuthoritiesController(IKhowBase knowbase)
    {
      KnowBaseRepository = knowbase;

    }

    // GET: Admin/Authorities
    public ActionResult Index()
    {
      var authoritys = KnowBaseRepository.Authoritys;
      return View(authoritys.ToList());
    }

    // GET: Admin/Authorities/Edit/5
    public ActionResult Edit(int id)
    {
      Authority authority = KnowBaseRepository.Authoritys.FirstOrDefault(s => s.Id == id);
      ViewBag.TerritoryList = new SelectList(KnowBaseRepository.Territorys, "Id", "Name", authority.TerritoryId);
      ViewBag.ViewAuthorityList = new SelectList(KnowBaseRepository.ViewAuthorits, "Id", "Name", authority.ViewAuthorityId);
      return View(authority);
    }

  
    [HttpPost]
    public ActionResult Edit(Authority authority,HttpPostedFileBase File)
    {
      if (ModelState.IsValid)
      {
        
        if (File != null)
        {
          authority.MapMimeType = File.ContentType;
          authority.Map = new byte[File.ContentLength];
          File.InputStream.Read(authority.Map, 0, File.ContentLength);
        }

        KnowBaseRepository.SaveAuthority(authority);
        TempData["message"] = string.Format("Изменения в органа \"{0}\" были сохранены", authority.Name);
        return RedirectToAction("Index");
      }
      else
      {
        return View(authority);
      }
    }


    public FileContentResult GetImage(int id)
    {
      Authority aut = KnowBaseRepository.Authoritys
        .FirstOrDefault(s => s.Id == id);
      if (aut != null)
      {
        return File(aut.Map, aut.MapMimeType);
      }
      else
      {
        return null;
      }

    }

    public ActionResult Create()
    {
      Authority authority = new Authority();

      ViewBag.TerritoryList = new SelectList(KnowBaseRepository.Territorys, "Id", "Name", authority.TerritoryId);
      ViewBag.ViewAuthorityList = new SelectList(KnowBaseRepository.ViewAuthorits, "Id", "Name", authority.ViewAuthorityId);
      return View("Edit", authority);
    }


    // GET: Admin/Authorities/Delete/5
    public ActionResult Delete(int id)
    {
      Authority delete = KnowBaseRepository.DeleteAuthority(id);
      if (delete != null)
      {
        TempData["message"] = string.Format("Орган власти c именем: {0} удалено", delete.Name);
      }
      return RedirectToAction("Index");
    }

  }
}
