using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Entities
{
  public class BranchMFC // График работы МФЦ Подразделение МФЦ
  {
    // Список рабочих дней
    public int Id { get; set; }
    [DisplayName("Название МФЦ")]
    [Required(ErrorMessage = "Пожалуйста введите название МФЦ")]
    public string NameMFC { get; set; } // Название МФЦ
    [DisplayName("Список рабочих дней")]
    public List<BranchWorkDayMFC> ListWorkTime { get; set; }

    public List<DepartmentMFC> ListDepartament { get; set; }


    public BranchMFC() { }

    public BranchMFC(bool flag)
    {
      if (flag)
      {
        ListWorkTime = new List<BranchWorkDayMFC>
        {
          new BranchWorkDayMFC() { TimeBegin = "00:00", TimeEnd = "00:00", NumberDayOfWeek = 0 },
          new BranchWorkDayMFC() { TimeBegin = "00:00", TimeEnd = "00:00", NumberDayOfWeek = 1 },
          new BranchWorkDayMFC() { TimeBegin = "00:00", TimeEnd = "00:00", NumberDayOfWeek = 2 },
          new BranchWorkDayMFC() { TimeBegin = "00:00", TimeEnd = "00:00", NumberDayOfWeek = 3 },
          new BranchWorkDayMFC() { TimeBegin = "00:00", TimeEnd = "00:00", NumberDayOfWeek = 4 },
          new BranchWorkDayMFC() { TimeBegin = "00:00", TimeEnd = "00:00", NumberDayOfWeek = 5 },
          new BranchWorkDayMFC() { TimeBegin = "00:00", TimeEnd = "00:00", NumberDayOfWeek = 6 }
        };
      }
    }

  }
  public class BranchWorkDayMFC // Список рабочих дней МФЦ
  {
    public int Id { get; set; }
    public BranchMFC BranchMFC { get; set; }
    [DisplayName("День Недели")]
    public int NumberDayOfWeek { get; set; }
    [DisplayName("C")]
    [DataType(DataType.Time)]
    public string TimeBegin { get; set; }
    [DisplayName("По")]
    [DataType(DataType.Time)]
    public string TimeEnd { get; set; }
    // Номер дня недели
    // Время с
    // Время по

    // 
    /// <summary>
    ///Расчет времени работы 
    /// </summary>
    /// <returns>Количество рабочих часов</returns>
    public int GetWorkTime()
    {
      int begin = Convert.ToInt32(this.TimeBegin.Replace(":",""));
      int end = Convert.ToInt32(this.TimeEnd.Replace(":",""));

      int rez = ((end - begin) / 100);

      return rez;
    }
    

  }
}
