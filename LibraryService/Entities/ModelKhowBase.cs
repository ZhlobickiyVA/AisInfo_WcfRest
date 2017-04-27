using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace LibraryService.KhowBase
{
  // Вид органа власти Федеральный, Минуципальный, Региональный
  public class ViewAuthority
  {
    [HiddenInput(DisplayValue = false)]
    public int Id { get; set; }
    [Display(Name = "Вид органа")]
    public string Name { get; set; }

  }
  /// <summary>
  /// Вид территории действия ОГВ
  /// </summary>
  public class Territory
  {
    [HiddenInput(DisplayValue = false)]
    public int Id { get; set; }
    [Display(Name = "Название территории")]
    public string Name { get; set; }
  }


  // Орган власти
  public class Authority
  {
    [HiddenInput(DisplayValue = false)]
    public int Id { get; set; }
    [Display(Name = "Название")]
    public string Name { get; set; }
    [Display(Name = "Сокр. Название")]
    public string SlName { get; set; }
    [Display(Name = "Id ФРГУ")]
    public string Frgu { get; set; }
    [Display(Name = "ОГРН")]
    public string Ogrn { get; set; }
    [Display(Name = "ИНН")]
    public string Inn { get; set; }
    [Display(Name = "Адрес")]
    public string Adress { get; set; }
    [Display(Name = "Ф.И.О. Руководителя")]
    public string FIOruk { get; set; }
    [Display(Name = "Телефон")]
    public string Phone { get; set; }
    [Display(Name = "Заметки")]
    [DataType(DataType.MultilineText)]
    public string Note { get; set; }
    [Display(Name = "Карта")]
    public byte[] Map { get; set; }

    
    [Display(Name = "Родительское ведомство")]
    public int? AuthorityId { get; set; }
    
    public Authority Auth { get; set; }
    [Display(Name = "Вид Органа")]
    public int ViewAuthorityId { get; set; }
    public ViewAuthority ViewAuth { get; set; }
    [Display(Name = "Территориальное расположение")]
    public int TerritoryId { get; set; }
    [Display(Name = "Территориальное расположение")]
    public Territory Terr { get; set; }
    [Display(Name = "Список услуг")]
    public List<Service> Service { get; set; }
    public string MapMimeType { get; set; }
  }


  public class Category
  {
    public int Id { get; set; }
    [Display(Name = "Название категории")]
    public string Name { get; set; }
  }


  // Услуги
  public class Service
  {
    [HiddenInput(DisplayValue = false)]
    public int Id { get; set; }
    [Display(Name = "Название")]
    public string Name { get; set; }
    [Display(Name = "Народное название")]
    public string SlName { get; set; }
    [Display(Name = "ФРГУ")]
    public string Frgu { get; set; }
    [Display(Name = "Доступна физическим лицам")]
    public bool FlPeople { get; set; }
    [Display(Name = "Доступна юридическим лицам")]
    public bool UnPeople { get; set; }
    [Display(Name = "Доступна ИП")]
    public bool IpPeople { get; set; }
    [Display(Name = "Доступна представителям")]
    public bool PerentPeople { get; set; }
    [Display(Name = "Информация по услуге")]

    [DataType(DataType.MultilineText)]
    public string Text { get; set; }
    [Display(Name = "Доступна в АИС")]
    public bool InAis { get; set; }
    [Display(Name = "Дата открытия в АИС")]
    [DataType(DataType.Date)]
    public DateTime AccessDate { get; set; }
    [Display(Name = "Категория услуги")]
    public int CategoryId { get; set; }
    [Display(Name = "Категория услуги")]
    public Category Categor { get; set; }
    [Display(Name = "Орган власти")]
    public int AuthorityId { get; set; }
    [Display(Name = "Орган власти")]
    public Authority Authory { get; set; }
  }

  

}
