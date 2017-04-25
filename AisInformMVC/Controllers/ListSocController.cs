using AisInformMVC.Models;
using LibraryService.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AisInformMVC.Controllers
{
  public class ListSocController : Controller
  {
    // GET: ListSoc
    private IListEdv ListEdvContext;
    private IListMdou ListMdouContext;
    private IListOldPeople ListOldPeopleContext;
    private IListPayKinder ListPayKinderContext;

    public ListSocController(IListEdv listEdv, IListMdou listMdou,IListOldPeople listOldPeople,IListPayKinder listPayKinder)
    {
      ListEdvContext = listEdv;
      ListMdouContext = listMdou;
      ListOldPeopleContext = listOldPeople;
      ListPayKinderContext = listPayKinder;
    }


    #region Список ДОУ
    public ActionResult ListDOU()
    {
      var list = ListMdouContext.ListMdou.ToList();
      var selectlist = list.OrderBy(x=>x.NumDou).Select(x=>x.NumDou).Distinct().ToList();
      selectlist.Insert(0,"Все");
      SelectList sel = new SelectList(selectlist);
      ViewListMdou viewlist = new ViewListMdou()
      {
        ListMdou = list.Take(30),
        SelectDou = sel
      };
      return View(viewlist);
    }
    [HttpPost]
    public ActionResult ListDOU(SearchListSocMdou search)
    {
      var list = ListMdouContext.ListMdou.ToList();
      var selectlist = list.OrderBy(x => x.NumDou).Select(x => x.NumDou).Distinct().ToList();
      selectlist.Insert(0, "Все");
      SelectList sel = new SelectList(selectlist);


      var res = list.Where(s => s.LastName.StartsWith(search.LastName ?? "")
        && s.FirstName.StartsWith(search.FirstName ?? "")
        && s.MiddleName.StartsWith(search.MiddleName ?? ""));
      if (search.DateBr != null)
      {
        res = res.Where(s => s.BrDate == Convert.ToDateTime(search.DateBr).Date);
      }
      if (search.NumDou != "Все")
      {
        res = res.Where(s => s.NumDou.StartsWith(search.NumDou));
      }
      
      ViewListMdou viewlist = new ViewListMdou()
      {
        ListMdou = res.Take(30),
        SelectDou = sel
      };
      return View(viewlist);
    }
    #endregion
    #region Список из Соц Центра ЕДВ
    [HttpPost]
    public ActionResult ListEDV(SearchListSoc search)
    {
      var list = ListEdvContext.ListEdv.ToList()
        .Where(s => s.LastName.StartsWith(search.LastName ?? "")
        && s.FirstName.StartsWith(search.FirstName ?? "")
        && s.MiddleName.StartsWith(search.MiddleName ?? ""));
      if (search.DateBr != null)
      {
        list = list.Where(s => s.BrDate == Convert.ToDateTime(search.DateBr).Date);
      }
      return View(list);
    }

    public ViewResult ListEDV()
    {
      return View(ListEdvContext.ListEdv.Take(30));
    }
    #endregion

    #region Информация по Старожилам

    
    [HttpPost]
    public ActionResult ListOldPeople(SearchListSoc search)
    {
      var list = ListOldPeopleContext.ListOldPeople.ToList()
        .Where(s => s.LastName.StartsWith(search.LastName ?? "")
        && s.FirstName.StartsWith(search.FirstName ?? "")
        && s.MiddleName.StartsWith(search.MiddleName ?? ""));
      if (search.DateBr != null)
      {
        list = list.Where(s => s.BrDate == Convert.ToDateTime(search.DateBr).Date);
      }
      return View(list);
    }
    
    public ActionResult ListOldPeople()
    {
      var list = ListOldPeopleContext.ListOldPeople.ToList();
      return View(list.Take(30));
    }
    #endregion



    #region Информация по Ежемесячному пособию на ребенка
    [HttpPost]
    public ActionResult ListPayKinder(SearchListSoc search)
    {
      var list = ListPayKinderContext.ListPayKinder.ToList()
        .Where(s => s.LastName.StartsWith(search.LastName ?? "")
        && s.FirstName.StartsWith(search.FirstName ?? "")
        && s.MiddleName.StartsWith(search.MiddleName ?? ""));
      if (search.DateBr != null)
      {
        list = list.Where(s => s.BrDate == Convert.ToDateTime(search.DateBr).Date);
      }
      return View(list);
    }
    public ActionResult ListPayKinder()
    {
      var list = ListPayKinderContext.ListPayKinder.ToList();
      return View(list.Take(30));
    }
    #endregion


  }
}

