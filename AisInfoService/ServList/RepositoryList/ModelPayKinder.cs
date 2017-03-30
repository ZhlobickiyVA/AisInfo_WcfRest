using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace AisInfoService
{
  // Список - Информация по Ежемесячному пособую на ребенка
  // Данные: Фамилия, Имя, Отчество, Дата рождения, Дата подачи заявления, Дата действия, Название выплаты, Основание
  // Поиск: Фамилия, Имя, Отчество, Дата рождения

  /// <summary>
  /// Дата контракт пособия на ребенка
  /// </summary>
  [DataContract]
  public class ItemPayKinder
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
    public string BrDate { get; set; }
    /// <summary>
    /// Дата действия
    /// </summary>
    [DataMember(Order = 4)]
    public string DateOfApplication { get; set; }
    /// <summary>
    /// Дата подачи заявления
    /// </summary>
    [DataMember(Order = 5)]
    public string EffictiveDate { get; set; }
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
  }

  public class ListPayKinder
  {
    /// <summary>
    /// Строка подключения к базе соц центра
    /// </summary>
    string Connect = ConfigurationManager.ConnectionStrings["ConnectListSocDB"].ConnectionString;
    string SelectCount = ConfigurationManager.AppSettings["CountSelect"];

    public ItemPayKinder[] GetListPayKinder(ItemPayKinder PayKinder = null)
    {
      string SQL = "";
      ItemPayKinder item = PayKinder;

      /// TODO: Заменить на хранимую процедуру.
      /// SELECT top 30 [FAMIL],[IMJA],[OTCH],[drog],[dzayv], 'C '+[date_begin]+' По '+[date_end] as 'DateOfApp',[nazn],[prim] FROM[mfc_out].[dbo].[det_pos]
      SQL = string.Format(
      "SELECT top {4} [FAMIL],[IMJA],[OTCH],[drog],[dzayv], 'C '+[date_begin]+' По '+[date_end] as 'DateOfApp',nkod,[nazn] FROM[mfc_out].[dbo].[det_pos]"
      + "where FAMIL like '{0}%' and IMJA like '{1}%' and OTCH like '{2}%'" + ((item.BrDate != "" && item.BrDate != null) ? " and drog = '{3}'" : ""),
      item.LastName, item.FirstName, item.MiddleName, item.BrDate, SelectCount);
      SqlConnection connection = new SqlConnection(Connect);
      SqlCommand Command = new SqlCommand()
      {
        Connection = connection,
        CommandType = CommandType.Text,
        CommandText = SQL
      };
      SqlDataAdapter data = new SqlDataAdapter()
      {
        SelectCommand = Command
      };
      DataSet ds = new DataSet();
      data.Fill(ds);
      connection.Close();

      int count = ds.Tables[0].Rows.Count;
      ItemPayKinder[] mas = new ItemPayKinder[count];

      DataTable table = ds.Tables[0];

      for (int i = 0; i < count; i++)
      {
        //SELECT top 30 [FAMIL],[IMJA],[OTCH],[drog],[dzayv],'DateOfApp',nkod,[nazn]
        item = new ItemPayKinder()
        {
          LastName = table.Rows[i].ItemArray[0].ToString(),
          FirstName = table.Rows[i].ItemArray[1].ToString(),
          MiddleName = table.Rows[i].ItemArray[2].ToString(),
          BrDate = table.Rows[i].ItemArray[3].ToString(),

          EffictiveDate = table.Rows[i].ItemArray[4].ToString(),
          DateOfApplication = table.Rows[i].ItemArray[5].ToString(),
          NamePay = table.Rows[i].ItemArray[6].ToString(),
          Base = table.Rows[i].ItemArray[7].ToString()
        };
        mas[i] = item;
      }

      return mas;

    }

  }
}