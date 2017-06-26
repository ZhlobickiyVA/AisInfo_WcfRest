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
    private IListGrant ListGrantContext;
    private int CountRecord = 30;


    public ListSocController(
      IListEdv listEdv
      , IListMdou listMdou
      ,IListOldPeople listOldPeople
      ,IListPayKinder listPayKinder
      ,IListGrant listgrant)
    {
      ListEdvContext = listEdv;
      ListMdouContext = listMdou;
      ListOldPeopleContext = listOldPeople;
      ListPayKinderContext = listPayKinder;
      ListGrantContext = listgrant;
    }

    public string ConvertStringSearch(string sea)
    {
      if (sea != null)
      {
        sea = sea.ToLower();
        char[] ch = sea.ToCharArray();
        ch[0] = char.ToUpper(ch[0]);
        return new string(ch);
      }
      return null;
    }





    #region Список Субсидий
    //ListGrant

    [HttpPost]
    public ActionResult ListGrant(SearchListSoc search)
    {

      var list = ListGrantContext.ListGrant.ToList()
        .OrderBy(s=>s.LastName)
        .Where(s => s.LastName.StartsWith(ConvertStringSearch(search.LastName) ?? "")
        && s.FirstName.StartsWith(ConvertStringSearch(search.FirstName) ?? "")
        && s.MiddleName.StartsWith(ConvertStringSearch(search.MiddleName) ?? ""));
      if (search.DateBr != null)
      {
        list = list.Where(s => s.DateOfBirth == Convert.ToDateTime(search.DateBr).Date);
      }
      return View(list.Take(CountRecord));
    }

    public ActionResult ListGrant()
    {
      var list = ListGrantContext.ListGrant.Take(CountRecord).ToList();
      return View(list);
    }






    #endregion 








    #region Список ДОУ
    public ActionResult ListDOU()
    {
      var list = ListMdouContext.ListMdou.ToList();
      var selectlist = list.OrderBy(x=>x.NumDou).Select(x=>x.NumDou).Distinct().ToList();

      selectlist.Insert(0,"Все");
      SelectList sel = new SelectList(selectlist);
      ViewListMdou viewlist = new ViewListMdou()
      {
        ListMdou = list.Take(CountRecord),
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



      var res = list.Where(s => s.LastName.StartsWith(ConvertStringSearch(search.LastName) ?? "")
        && s.FirstName.StartsWith(ConvertStringSearch(search.FirstName) ?? "")
        && s.MiddleName.StartsWith(ConvertStringSearch(search.MiddleName) ?? ""));

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
        ListMdou = res.Take(CountRecord),
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
        .Where(s => s.LastName.StartsWith(ConvertStringSearch(search.LastName) ?? "")
        && s.FirstName.StartsWith(ConvertStringSearch(search.FirstName) ?? "")
        && s.MiddleName.StartsWith(ConvertStringSearch(search.MiddleName) ?? ""));
      if (search.DateBr != null)
      {
        list = list.Where(s => s.BrDate == Convert.ToDateTime(search.DateBr).Date);
      }
      return View(list.Take(CountRecord));
    }

    public ViewResult ListEDV()
    {
      return View(ListEdvContext.ListEdv.Take(CountRecord).ToList());
    }
    #endregion

    #region Информация по Старожилам

    
    [HttpPost]
    public ActionResult ListOldPeople(SearchListSoc search)
    {

      var list = ListOldPeopleContext.ListOldPeople.ToList()
        .Where(s => s.LastName.StartsWith(ConvertStringSearch(search.LastName) ?? "")
        && s.FirstName.StartsWith(ConvertStringSearch(search.FirstName) ?? "")
        && s.MiddleName.StartsWith(ConvertStringSearch(search.MiddleName) ?? ""));
      if (search.DateBr != null)
      {
        list = list.Where(s => s.BrDate == Convert.ToDateTime(search.DateBr).Date);
      }
      return View(list.Take(CountRecord));
    }
    
    public ActionResult ListOldPeople()
    {
      var list = ListOldPeopleContext.ListOldPeople.Take(CountRecord).ToList();
      return View(list);
    }
    #endregion



    #region Информация по Ежемесячному пособию на ребенка
    [HttpPost]
    public ActionResult ListPayKinder(SearchListSoc search)
    {


      var list = ListPayKinderContext.ListPayKinder.ToList()
        .Where(s => s.LastName.StartsWith(ConvertStringSearch(search.LastName) ?? "")
        && s.FirstName.StartsWith(ConvertStringSearch(search.FirstName) ?? "")
        && s.MiddleName.StartsWith(ConvertStringSearch(search.MiddleName) ?? ""));
      if (search.DateBr != null)
      {
        list = list.Where(s => s.BrDate == Convert.ToDateTime(search.DateBr).Date);
      }
      return View(list.Take(CountRecord));
    }
    public ActionResult ListPayKinder()
    {
      var list = ListPayKinderContext.ListPayKinder.Take(CountRecord).ToList();
      return View(list);
    }
    #endregion


  }
}

