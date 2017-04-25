using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService
{
  // Вид органа власти Федеральный, Минуципальный, Региональный
  public class ViewAuthority
  {
    public int Id { get; set; }
    public string Name { get; set; }

  }
  /// <summary>
  /// Вид территории действия ОГВ
  /// </summary>
  public class Territory
  {
    public int Id { get; set; }
    public string Name { get; set; }
  }


  // Орган власти
  public class Authority
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string SlName { get; set; }
    public string Frgu { get; set; }
    public string Ogrn { get; set; }
    public string Inn { get; set; }
    public string Adress { get; set; }
    public string FIOruk { get; set; }
    public string Phone { get; set; }
    public string Note { get; set; }
    public byte[] Map { get; set; }

    public int? AuthorityId { get; set; }
    public Authority Auth { get; set; }

    public int ViewAuthorityId { get; set; }
    public ViewAuthority ViewAuth { get; set; }

    public int TerritoryId { get; set; }
    public Territory Terr { get; set; }

    public List<Service> Service { get; set; }

  }


  public class Category
  {
    public int Id { get; set; }
    public string Name { get; set; }
  }


  // Услуги
  public class Service
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string SlName { get; set; }
    public string Frgu { get; set; }
    public bool FlPeople { get; set; }
    public bool UnPeople { get; set; }
    public bool IpPeople { get; set; }
    public bool PerentPeople { get; set; }
    public string Text { get; set; }
    public bool InAis { get; set; }
    public DateTime AccessDate { get; set; }

    public int CategoryId { get; set; }
    public Category Categor { get; set; }

    public int AuthorityId { get; set; }
    public Authority Authory { get; set; }
  }

  

}
