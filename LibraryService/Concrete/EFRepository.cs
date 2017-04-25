using LibraryService.Abstract;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryService.Price;
using System.Data.Entity;

namespace LibraryService.Concrete
{
  class EFRepository
  {
  }


  // Платежный документ

  public class EfPriceDocRepository : IPriceDocument
  {
    PriceDocContext price = new PriceDocContext();


    public IEnumerable<AuthoryPrice> AuthoryPrices
    {
      get { return price.AuthoryPrice; }
    }

    public IEnumerable<Purpose> Purposes
    {
      get { return price.Purposes; }
    }

    public IEnumerable<Document> Documents
    {
      get { return price.Documents; }
    }


  }






  //
  public class EfAdRepository : IAdRepository
  {
    AdContext adcontext = new AdContext();

    public IEnumerable<Ad> Ads
    {
      get { return adcontext.Ads; }
    }

    public Ad DeleteAd(int Id)
    {
      Ad dbEntry = adcontext.Ads.Find(Id);
      if (dbEntry != null)
      {
        adcontext.Ads.Remove(dbEntry);
        adcontext.SaveChanges();

      }
      return dbEntry;

    }

    public void SaveAd(Ad ad)
    {
      if (ad.Id == 0) adcontext.Ads.Add(ad);
      else
      {
        Ad dbEntry = adcontext.Ads.Find(ad.Id);
        if (dbEntry != null)
        {
          dbEntry.Header = ad.Header;
          dbEntry.Text = ad.Text;
          dbEntry.TheValidity = ad.TheValidity;
        }

      }
      adcontext.SaveChanges();
    }
  }


  public class EfEmployeesRepository : IEmployeesRepository
  {
    EmployeeContext emplcontext = new EmployeeContext();

    public IEnumerable<Employee> Staff
    {
      get { return emplcontext.Staff; }
    }
  }

  public class EfHolidayrepository : IHoliDayRepository
  {
    HolidayContext holicontext = new HolidayContext();

    public IEnumerable<Holiday> Holidays
    {
      get { return holicontext.Holidays; }

    }
  }




  public class EfListEdvRepository : IListEdv
  {
    static IEnumerable<ItemEDV> GetListEDV()
    {
      List<ItemEDV> list = new List<ItemEDV>();
      DataSet ds = new SelectToData("ConnectListSocDB").GetDatasetToBase(new ItemEDV());
      DataTable table = ds.Tables[0];
      for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
      {
        //[fm],[im],[ot], dtr,[cat_name]
        list.Add(
        new ItemEDV()
        {
          LastName = table.Rows[i].ItemArray[0].ToString(),
          FirstName = table.Rows[i].ItemArray[1].ToString(),
          MiddleName = table.Rows[i].ItemArray[2].ToString(),
          BrDate = (DateTime)table.Rows[i].ItemArray[3],
          Category = table.Rows[i].ItemArray[4].ToString()
        });
      }
      return list;
    }

    public IEnumerable<ItemEDV> ListEdv
    {
      get { return GetListEDV(); }
    }
  }

  public class EfListMdouRepository : IListMdou
  {
    static IEnumerable<KinderItem> GetListMdou()
    {
      List<KinderItem> list = new List<KinderItem>();
      DataSet ds = new SelectToData("ConnectListSocDB").GetDatasetToBase(new KinderItem());
      DataTable table = ds.Tables[0];
      for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
      {
        //[fm],[im],[ot], dtr,[cat_name]
        list.Add(
        new KinderItem()
        {
          LastName = table.Rows[i].ItemArray[0].ToString(),
          FirstName = table.Rows[i].ItemArray[1].ToString(),
          MiddleName = table.Rows[i].ItemArray[2].ToString(),
          BrDate = (DateTime)table.Rows[i].ItemArray[3],
          NumDou = table.Rows[i].ItemArray[4].ToString(),
          PayOut = table.Rows[i].ItemArray[5].ToString()
        });
      }
      return list;
    }

    public IEnumerable<KinderItem> ListMdou
    {
      get { return GetListMdou(); }
    }
  }

  public class EFListPayKinderRepository : IListPayKinder
  {
    public static IEnumerable<ItemPayKinder> GetListPayKinder()
    {
      DataSet ds = new SelectToData("ConnectListSocDB").GetDatasetToBase(new ItemPayKinder());
      List<ItemPayKinder> list = new List<ItemPayKinder>();
      foreach (var item in ds.Tables[0].AsEnumerable())
      {
        list.Add(
          new ItemPayKinder()
          {
            LastName = item.ItemArray[0].ToString(),
            FirstName = item.ItemArray[1].ToString(),
            MiddleName = item.ItemArray[2].ToString(),
            BrDate = (DateTime)item.ItemArray[3],
            EffictiveDate = (DateTime)item.ItemArray[4],
            DateOfApplication = item.ItemArray[5].ToString(),
            NamePay = item.ItemArray[6].ToString(),
            Base = item.ItemArray[7].ToString()
          });
      }
      return list;
    }

    public IEnumerable<ItemPayKinder> ListPayKinder
    {
      get { return GetListPayKinder(); }
    }
  }


  public class EFListOldPeopleRepository : IListOldPeople
  {
    public static IEnumerable<ItemOldLive> GetListOldLive()
    {
      DataSet ds = new SelectToData("ConnectListSocDB").GetDatasetToBase(new ItemOldLive());
      List<ItemOldLive> list = new List<ItemOldLive>();
      foreach (var it in ds.Tables[0].AsEnumerable())
      {
        list.Add(
          new ItemOldLive()
          {
            LastName = it.ItemArray[0].ToString(),
            FirstName = it.ItemArray[1].ToString(),
            MiddleName = it.ItemArray[2].ToString(),
            BrDate = (DateTime)it.ItemArray[3],
            Category = it.ItemArray[4].ToString()
          });
      }
      return list;
    }
    public IEnumerable<ItemOldLive> ListOldPeople
    {
      get { return GetListOldLive(); }
    }
  }

  





}
