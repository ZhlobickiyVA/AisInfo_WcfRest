using LibraryService.Abstract;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryService.Price;
using System.Data.Entity;
using LibraryService.KhowBase;
using LibraryService;
using LibraryService.Entities;

namespace LibraryService.Concrete
{
  class EFRepository
  {
  }

  // База знаний

  public class EfKnowBaseRepository : IKhowBase
  {
    KnowBaseContext context = new KnowBaseContext();

    public IEnumerable<ViewAuthority> ViewAuthorits
    {
      get { return context.ViewAuthoritys; }
    }

    public IEnumerable<Territory> Territorys
    {
      get { return context.Territorys; }
    }

    public IEnumerable<Authority> Authoritys
    {
      get
      {
        return context.Authoritys
      .Include(c => c.Auth)
      .Include(c => c.ViewAuth)
      .Include(c => c.Terr);
      }
    }

    public IEnumerable<Category> Categorys
    {
      get { return context.Category; }
    }

    public IEnumerable<Service> Services
    {
      get { return context.Services.Include(c => c.Categor).Include(c => c.Authory); }
    }

    public Authority DeleteAuthority(int Id)
    {
      Authority dbEntry = context.Authoritys.Find(Id);
      if (dbEntry != null)
      {
        context.Authoritys.Remove(dbEntry);
        context.SaveChanges();

      }
      return dbEntry;
    }
    public Service DeleteService(int Id)
    {
      Service dbEntry = context.Services.Find(Id);
      if (dbEntry != null)
      {
        context.Services.Remove(dbEntry);
        context.SaveChanges();

      }
      return dbEntry;
    }

    public void SaveAuthority(Authority aut)
    {
      if (aut.Id == 0) context.Authoritys.Add(aut);
      else
      {
        Authority dbEntry = context.Authoritys.Find(aut.Id);
        if (dbEntry != null)
        {
          dbEntry.Name = aut.Name;
          dbEntry.SlName = aut.SlName;
          dbEntry.Frgu = aut.Frgu;
          dbEntry.Ogrn = aut.Ogrn;
          dbEntry.Inn = aut.Inn;
          dbEntry.Adress = aut.Adress;
          dbEntry.FIOruk = aut.FIOruk;
          dbEntry.Phone = aut.Phone;
          dbEntry.Note = aut.Note;

          if (dbEntry.Map == null) dbEntry.Map = aut.Map;
          else
          {
            if (aut.Map != null) dbEntry.Map = aut.Map;
          }



          dbEntry.ViewAuthorityId = aut.ViewAuthorityId;
          dbEntry.TerritoryId = aut.TerritoryId;
          dbEntry.Service = aut.Service;
          dbEntry.MapMimeType = aut.MapMimeType;

        }
      }
      context.SaveChanges();
    }

    public void SaveService(Service serv)
    {
      if (serv.Id == 0)
      {
        if (serv.InAis)
        {
          serv.AccessDate = DateTime.Now;
        }
        else serv.AccessDate = DateTime.Parse("01.01.2000");

        context.Services.Add(serv);
      }
      else
      {
        Service dbEntry = context.Services.Find(serv.Id);
        if (dbEntry != null)
        {

          dbEntry.Name = serv.Name;
          dbEntry.SlName = serv.SlName;
          dbEntry.Frgu = serv.Frgu;
          dbEntry.FlPeople = serv.FlPeople;
          dbEntry.UnPeople = serv.UnPeople;
          dbEntry.IpPeople = serv.IpPeople;
          dbEntry.PerentPeople = serv.PerentPeople;
          dbEntry.Text = serv.Text;
          dbEntry.InAis = serv.InAis;



          dbEntry.CategoryId = serv.CategoryId;
          dbEntry.AuthorityId = serv.AuthorityId;

        }
      }
      context.SaveChanges();
    }
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

  // список сотрудников и дней рождений
  public class EfEmployeesRepository : IEmployeesRepository
  {
    EmployeeContext emplcontext = new EmployeeContext();

    public IEnumerable<Employee> Staff
    {
      get { return emplcontext.Staff; }
    }

    public Employee DeleteEmpl(int Id)
    {
      Employee dbEntry = emplcontext.Staff.Find(Id);
      if (dbEntry != null)
      {
        emplcontext.Staff.Remove(dbEntry);
        emplcontext.SaveChanges();

      }
      return dbEntry;

    }

    public void SaveEmpl(Employee Empl)
    {
      if (Empl.Id == 0) emplcontext.Staff.Add(Empl);
      else
      {
        Employee dbEntry = emplcontext.Staff.Find(Empl.Id);
        if (dbEntry != null)
        {
          dbEntry.LastName = Empl.LastName;
          dbEntry.FirstName = Empl.FirstName;
          dbEntry.MiddleName = Empl.MiddleName;
          dbEntry.DateOfBirth = Empl.DateOfBirth;
          dbEntry.Post = Empl.Post;
        }
      }
      emplcontext.SaveChanges();
    }

  }

  // Список обьявлений
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

  // Список правздников
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

  // Список субсидий соц центр

  public class EfListGrantRepository : IListGrant
  {
    public IEnumerable<ModelGrant> GetListGrant()
    {
      DataSet ds = new SelectToData("ConnectListSocDB").GetDatasetToBase(new ModelGrant());
      List<ModelGrant> listGrant = new List<ModelGrant>();
      foreach (var it in ds.Tables[0].AsEnumerable())
      {
        listGrant.Add(
           new ModelGrant()
           {
             LastName = it.ItemArray[0].ToString(),
             FirstName = it.ItemArray[1].ToString(),
             MiddleName = it.ItemArray[2].ToString(),
             DateOfBirth = (DateTime)it.ItemArray[3],
             PeriodFrom = (DateTime)it.ItemArray[4],
             PeriodTo = (DateTime)it.ItemArray[5],
             ReasonForTheSuspension = it.ItemArray[6].ToString(),
             Adress =
             it.ItemArray[7].ToString() //Населенный пункт
             + " " + it.ItemArray[8].ToString() //Улица
             + " д." + it.ItemArray[9].ToString() //Дом
             + ((it.ItemArray[10].ToString() != "") ? ("/" + it.ItemArray[10].ToString()) : "")//Корпус
             + ((it.ItemArray[11].ToString() != "") ? (" кв. " + it.ItemArray[11].ToString()) : "") //Квартира
             + ((it.ItemArray[12].ToString() != "") ? String.Format(" ком. {0}", it.ItemArray[12].ToString()) : "") //Комната
           });
      }
      return listGrant;
    }

    public IEnumerable<ModelGrant> ListGrant
    {
      get
      {
        return GetListGrant();
      }
    }
  }

  public class EfDictionaryRepository : IDictionaryList
  {
    DictionaryContext context = new DictionaryContext();

    public IEnumerable<ModelDictionary> DictionaryList
    {
      get { return context.DictionaryList; }
    }

    public ModelDictionary DeleteDictionary(int id)
    {
      throw new NotImplementedException();
    }

    public void SaveDictionary(ModelDictionary Dict)
    {
      if (Dict.Id == 0) context.DictionaryList.Add(Dict);
      else
      {
        ModelDictionary dbEntry = context.DictionaryList.Find(Dict.Id);
        if (dbEntry != null)
        {
          dbEntry.Type = Dict.Type;
          dbEntry.Value = Dict.Value;
        }
      }
      context.SaveChanges();
    }
  }
  public class EfBranchMfcRepository : IBranchMfcWork
  {
    BranchMfcContext context = new BranchMfcContext();

    public IEnumerable<BranchMFC> ListBranchMFC
    {
      get { return context.ListBranchMFC.Include(s => s.ListWorkTime).Include(s=>s.ListDepartament); }
    }
    
    public BranchMFC DeleteBranchMfc(int id)
    {
      BranchMFC dbEntry = context.ListBranchMFC.Include(s=>s.ListWorkTime).FirstOrDefault(s=>s.Id == id);
      if (dbEntry != null)
      {
        context.ListBranchMFC.Remove(dbEntry);
        context.SaveChanges();
        context.ListWorkDayMFC.RemoveRange(context.ListWorkDayMFC.Where(s => s.BranchMFC == null));
        context.SaveChanges();
      }
      return dbEntry;
    }

    public void SaveBranchMfc(BranchMFC BranchMfc)
    {
      if (BranchMfc.Id == 0) context.ListBranchMFC.Add(BranchMfc);
      else
      {
        BranchMFC dbEntry = context.ListBranchMFC.Include(s=>s.ListWorkTime).FirstOrDefault(s=>s.Id == BranchMfc.Id);
        if (dbEntry != null)
        {
          dbEntry.NameMFC = BranchMfc.NameMFC;
          for (int i = 0; i < BranchMfc.ListWorkTime.Count; i++)
          {
            dbEntry.ListWorkTime[i].TimeBegin = BranchMfc.ListWorkTime[i].TimeBegin;
            dbEntry.ListWorkTime[i].TimeEnd = BranchMfc.ListWorkTime[i].TimeEnd;
          }
          dbEntry.ListWorkTime = BranchMfc.ListWorkTime;
        }
      }
      context.SaveChanges();
      context.ListWorkDayMFC.RemoveRange(context.ListWorkDayMFC.Where(s=>s.BranchMFC == null));
      context.SaveChanges();
      
    }


    public IEnumerable<DepartmentMFC> ListDepartamentMFC
    {
      get { return context.ListDepartments ; }
    }

    public void SaveDepartament(DepartmentMFC DepartmentMFC)
    {
      if (DepartmentMFC.Id == 0) context.ListDepartments.Add(DepartmentMFC);
      else
      {
        DepartmentMFC dbEntry = context.ListDepartments.FirstOrDefault(s=>s.Id == DepartmentMFC.Id);
        if (dbEntry != null)
        {
          dbEntry.Name = DepartmentMFC.Name;
          dbEntry.BranchMFC = DepartmentMFC.BranchMFC;
        }
      }
      context.SaveChanges();
    }
    public DepartmentMFC DeleteDepartmentMfc(int id)
    {
      DepartmentMFC dbEntry = context.ListDepartments.FirstOrDefault(s=>s.Id == id);
      if (dbEntry != null)
      {
        context.ListDepartments.Remove(dbEntry);
        context.SaveChanges();
      }
      return dbEntry;
    }


  }
  }







