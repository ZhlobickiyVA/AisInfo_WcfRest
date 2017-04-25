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
  // Обьявления
  public class Ad
  {
    [HiddenInput(DisplayValue = false)]
    public int Id { get; set; }

    [Display(Name = "Заголовок")]
    [Required(ErrorMessage = "Пожалуйста введите заголовок обьявления")]
    public string Header { get; set; }

    [Display(Name = "Текст")]
    [DataType(DataType.MultilineText)]
    [Required(ErrorMessage ="Пожалуйста, введите тело обьявления")]
    public string Text { get; set; }

    
    [Required(ErrorMessage ="Пожалуйста, введите дату окончания действия обьявления")]
    [Display(Name = "Обьявление актуально до:")]
    [DataType(DataType.Date)]
    [UIHint("Date")]
    public DateTime TheValidity { get; set; }
  }

 
}
