using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace LibraryService
{
  // Дни рождения таблица сотрудники
  public class Employee
  {
    [HiddenInput(DisplayValue =false)]
    public int Id { get; set; }

    [Display(Name ="Фамилия")]
    [Required(ErrorMessage = "Пожалуйста введите фамилию сотрудника")]
    public string LastName { get; set; }

    [Display(Name ="Имя")]
    [Required(ErrorMessage = "Пожалуйста введите имя сотрудника")]
    public string FirstName { get; set; }

    [Display(Name ="Отчество")]
    [Required(ErrorMessage = "Пожалуйста введите отчество сотрудника")]
    public string MiddleName { get; set; }

    [DataType(DataType.Date)]
    [UIHint("Date")]
    [Display(Name ="Дата рождения")]
    public DateTime DateOfBirth { get; set; }

    [Display(Name ="Должность")]
    public string Post { get; set; }



    public string GetShortName()
    {
      return String.Format("{0} {1}.{2}.",LastName,FirstName[0],MiddleName[0]);
    }



  }


}
