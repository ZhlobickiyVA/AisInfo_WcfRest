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


  // Список - Информация по ЕДВ
  //Данные: Фамилия, Имя, Отчество, Дата рождения, Категория
  //Поиск: Фамилия, Имя, Отчество, Дата рождения

  /// <summary>
  /// Дата контракт Список ЕДВ
  /// </summary>
  [DataContract]
  public class ItemEDV : IConnectString
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
    /// Категория
    /// </summary>
    [DataMember(Order = 4)]
    public string Category { get; set; }


    public string GetTextQuery()
    {
      string SQL = string.Format(
      "SELECT [fm],[im],[ot], convert(date, dtr, 104),[cat_name] FROM [mfc_out].[dbo].[EDV_OR]");
        return SQL;
    }

    
  }

  


  }
