using AisInformMVC.Models;
using LibraryService.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AisInformMVC.Controllers
{
  public class KhowBaseController : Controller
  {
    private IKhowBase KnowBaseRepository;
    public KhowBaseController(IKhowBase khowbase)
    {
      KnowBaseRepository = khowbase;
    }


    // GET: KhowBase
    public ActionResult Index()
    {
      ViewKnowBase view = new ViewKnowBase()
      {
        Authoritys = KnowBaseRepository.Authoritys.ToList(),
        Services = KnowBaseRepository.Services.ToList(),
        ViewAuthoritys = KnowBaseRepository.ViewAuthorits.ToList()
      };

      return View(view);
    }
    [HttpPost]
    public ActionResult Index(string search)
    {
      ViewKnowBase view = new ViewKnowBase()
      {
        Authoritys = KnowBaseRepository.Authoritys.Where(s=>s.Name.IndexOf(search)>-1),
        Services = KnowBaseRepository.Services.ToList(),
        ViewAuthoritys = KnowBaseRepository.ViewAuthorits.ToList()
      };
      ViewBag.Search = search;
      return View(view);
    }

    public ActionResult DetailsServices(int id)
    {
      var service = KnowBaseRepository.Services.FirstOrDefault(s=>s.Id == id);
      return View(service);
    }

  }
}