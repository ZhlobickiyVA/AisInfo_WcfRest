using LibraryService.Price;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Abstract
{
  //public interface IRepository
  //{

  //}

  public interface IAdRepository
  {
    IEnumerable<Ad> Ads { get; }
    void SaveAd(Ad ad);
    Ad DeleteAd(int Id);
  }

  public interface IEmployeesRepository
  {
    IEnumerable<Employee> Staff { get; }
  }
  public interface IHoliDayRepository
  {
    IEnumerable<Holiday> Holidays { get; }
  }




  // Списки соц центра

  public interface IListEdv
  {
    IEnumerable<ItemEDV> ListEdv { get; }
  }

  public interface IListMdou
  {
    IEnumerable<KinderItem> ListMdou { get; }
  }

  public interface IListOldPeople
  {
    IEnumerable<ItemOldLive> ListOldPeople { get; }
  }

  public interface IListPayKinder
  {
    IEnumerable<ItemPayKinder> ListPayKinder { get; }
  }

  // Платежная квитанция

  public interface IPriceDocument
  {
    IEnumerable<AuthoryPrice> AuthoryPrices { get; }
    IEnumerable<Purpose> Purposes { get; }
    IEnumerable<Document> Documents { get; }

    
  }

}
