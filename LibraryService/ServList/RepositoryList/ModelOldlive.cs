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
  // Список - Информация по Старожилам
  // Данные: Фамилия, Имя, Отчество, Дата рождения, Категория
  // Поиск: Фамилия, Имя, Отчество, Дата рождения

  [DataContract]
  public class ItemOldLive
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
    public string BrDate { get; set; }
    /// <summary>
    /// Категория
    /// </summary>
    [DataMember(Order = 4)]
    public string Category { get; set; }
  }

  public class ListOldLive
  {
    /// <summary>
    /// Строка подключения к базе соц центра
    /// </summary>
    string Connect = ConfigurationManager.ConnectionStrings["ConnectListSocDB"].ConnectionString;
    string SelectCount = ConfigurationManager.AppSettings["CountSelect"];

    public ItemOldLive[] GetListOldLive(ItemOldLive oldlive = null)
    {
      string SQL = "";
      ItemOldLive item = oldlive;

      /// TODO: Заменить на хранимую процедуру.
      /// SELECT top 10 [fm],[im],[ot],convert(date, dtr,104),[cat_name] FROM[mfc_out].[dbo].[star]
      SQL = string.Format(
      "SELECT top {4} [fm],[im],[ot],convert(date, dtr,104),[cat_name] FROM[mfc_out].[dbo].[star]"
      + "where fm like '{0}%' and im like '{1}%' and ot like '{2}%'" + ((item.BrDate != "" && item.BrDate != null) ? " and dtr = '{3}'" : ""),
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
      ItemOldLive[] mas = new ItemOldLive[count];

      DataTable table = ds.Tables[0];

      for (int i = 0; i < count; i++)
      {
        //[fm],[im],[ot], dtr,[cat_name]
        item = new ItemOldLive()
        {
          LastName = table.Rows[i].ItemArray[0].ToString(),
          FirstName = table.Rows[i].ItemArray[1].ToString(),
          MiddleName = table.Rows[i].ItemArray[2].ToString(),
          BrDate = ((DateTime)table.Rows[i].ItemArray[3]).ToShortDateString(),
          Category = table.Rows[i].ItemArray[4].ToString()
        };
        mas[i] = item;
      }

      return mas;

    }
  }
}