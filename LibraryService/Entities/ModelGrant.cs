using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Entities
{
  public class ModelGrant:IConnectString
  {
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public DateTime PeriodFrom { get; set; }
    public DateTime PeriodTo { get; set; }
    public string ReasonForTheSuspension { get; set; }
    public string Adress { get; set; }

    public string GetTextQuery()
    {
      return "select * from mfc_out..subs";
    }
  }
}
//SELECT
//    [Фамилия] as 'LastName'
//      ,[Имя] as 'FirstName'
//      ,[Отчество] as 'MiddleName'
//      ,[Дата рождения] as 'DateOfBirth'
//      ,[Период с] as 'PeriodFrom'
//      ,[Период по] as 'PeriodTo'
//      ,[Причина приостановки] as 'ReasonForTheSuspension' 
//      ,[Населенный пункт] +' '+ [Улица] +' , '+[Дом] +' , '+ [Корпус] +' , '+[Квартира]+','+[Комната] as 'Address'
//  FROM[mfc_out].[dbo].[subs]

//  --Grant