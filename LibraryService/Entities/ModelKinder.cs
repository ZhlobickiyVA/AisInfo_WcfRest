using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace LibraryService
{
  // LastName - Фамилия
  // FirstName - Имя
  // MiddleName - Отчество
  // BrDate - Дата рождения
  // NumDou - Номер ДОУ
  // PayOut - Размер выплаты 

  // Модель данных для Информация по ДОУ

  // Список - Информация по ДОУ
  // Данные: Фамилия, Имя, Отчество, Дата рождения, №ДОУ, % выплаты
  // Поиск: Фамилия, Имя, Отчество, Дата рождения, №ДОУ
  // Дополнительно: Поиск по списку ДОУ.

  /// <summary>
  /// Дата контракт Список ДОУ
  /// </summary>
  [DataContract]
  public class KinderItem :IConnectString
  {
    /// <summary>
    /// Фамилия
    /// </summary>
    [DataMember(Order = 0)]
    public string LastName { get; set; }
    /// <summary>
    /// Имя
    /// </summary>
    [DataMember(Order = 1)]
    public string FirstName { get; set; }
    /// <summary>
    /// Отчество
    /// </summary>
    [DataMember(Order = 2)]
    public string MiddleName { get; set; }
    /// <summary>
    /// Дата рождения
    /// </summary>
    [DataMember(Order = 3)]
    public DateTime BrDate { get; set; }
    /// <summary>
    /// Номер ДОУ
    /// </summary>
    [DataMember(Order = 4)]
    public string NumDou { get; set; }
    /// <summary>
    /// Размер выплаты
    /// </summary>
    [DataMember(Order = 5)]
    public string PayOut { get; set; }



    public string GetTextQuery()
    {
      string SelectCount = ConfigurationManager.AppSettings["CountSelect"];
      string SQL = string.Format(
      "SELECT [FMR],[IMR],[OTR],CONVERT(date, [DTR] ,104 ) as DTRda, (Case when DATALENGTH([NUMDOU])<>2 then '0'+NUMDOU else NUMDOU end) ,[RAZML] FROM [mfc_out].[dbo].[dou_lg]");
      return SQL;
    }

   
  }

  }

