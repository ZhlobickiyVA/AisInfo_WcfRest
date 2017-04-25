using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService
{
  // Дни рождения таблица сотрудники
  public class Employee
  {
    public int Id { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Post { get; set; }

    public string GetShortName()
    {
      return String.Format("{0} {1}.{2}.",LastName,FirstName[0],MiddleName[0]);
    }



  }


}
