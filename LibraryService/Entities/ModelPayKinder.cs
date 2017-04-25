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
  // Список - Информация по Ежемесячному пособую на ребенка
  // Данные: Фамилия, Имя, Отчество, Дата рождения, Дата подачи заявления, Дата действия, Название выплаты, Основание
  // Поиск: Фамилия, Имя, Отчество, Дата рождения

  /// <summary>
  /// Дата контракт пособия на ребенка
  /// </summary>
  [DataContract]
  public class ItemPayKinder :IConnectString
  {
    /// <summary>
    /// Фамилия
    /// </summary>
    [DataMember(Order = 0)]
    public string LastName { get; set; }
    /// <summary>
    ///Имя
    /// </summary>
    [DataMember(Order = 1)]
    public string FirstName { get; set; }
    /// <summary>
    ///Отчество
    /// </summary>
    [DataMember(Order = 2)]
    public string MiddleName { get; set; }
    /// <summary>
    /// Дата рождения
    /// </summary>
    [DataMember(Order = 3)]
    public DateTime BrDate { get; set; }
    /// <summary>
    /// Дата действия
    /// </summary>
    [DataMember(Order = 4)]
    public string DateOfApplication { get; set; }
    /// <summary>
    /// Дата подачи заявления
    /// </summary>
    [DataMember(Order = 5)]
    public DateTime EffictiveDate { get; set; }
    /// <summary>
    /// Название выплаты
    /// </summary>
    [DataMember(Order = 6)]
    public string NamePay { get; set; }
    /// <summary>
    /// Основание
    /// </summary>
    [DataMember(Order = 7)]
    public string Base { get; set; }

    public string GetTextQuery()
    {
      string SQL = string.Format("SELECT [FAMIL],[IMJA],[OTCH],convert(date, [drog],104),convert(date, [dzayv],104), 'C '+[date_begin]+' По '+[date_end] as 'DateOfApp',nkod,[nazn] FROM[mfc_out].[dbo].[det_pos] order by [FAMIL],[IMJA],[OTCH]");
      return SQL;
    }
  }
}