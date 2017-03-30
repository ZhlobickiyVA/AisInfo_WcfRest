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
  public class KinderItem
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
    /// Номер ДОУ
    /// </summary>
    [DataMember(Order = 4)]
    public string NumDou { get; set; }
    /// <summary>
    /// Размер выплаты
    /// </summary>
    [DataMember(Order = 5)]
    public string PayOut { get; set; }
  }




  public class ListKinder
  {
    /// <summary>
    /// Строка подключения к базе соц центра
    /// </summary>
    string Connect = ConfigurationManager.ConnectionStrings["ConnectListSocDB"].ConnectionString;
    string SelectCount = ConfigurationManager.AppSettings["CountSelect"];
    /// Получить список "Информации по ДОУ"
    /// </summary>
    /// <param name="kinder">[параметры] Обьект поиска в списке</param>
    /// <returns>Результат поиска Массив kinderItem</returns>
    public KinderItem[] GetListKinder(KinderItem kinder = null)
    {
      string SQL = "";
      KinderItem item = kinder;

      /// TODO: Заменить на хранимую процедуру.
      SQL = string.Format(
      "SELECT TOP {5} [FMR],[IMR],[OTR],CONVERT(date, [DTR] ,104 ) as DTRda,[NUMDOU],[RAZML] FROM [mfc_out].[dbo].[dou_lg] "
      + "where FMR like '{0}%' and IMR like '{1}%' and OTR like '{2}%'" + ((item.BrDate != "" && item.BrDate != null) ? " and DTR = '{3}'" : ""
      + "and NUMDOU like '%{4}'"),
      item.LastName, item.FirstName, item.MiddleName, item.BrDate, ((item.NumDou == null) ? "" : Convert.ToInt32(item.NumDou).ToString()), SelectCount);
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

      int countkinder = ds.Tables[0].Rows.Count;
      KinderItem[] mas = new KinderItem[countkinder];

      DataTable table = ds.Tables[0];

      for (int i = 0; i < countkinder; i++)
      {
        //[FMR],[IMR],[OTR],[DTR],[NUMDOU],[RAZML]
        item = new KinderItem()
        {
          LastName = table.Rows[i].ItemArray[0].ToString(),
          FirstName = table.Rows[i].ItemArray[1].ToString(),
          MiddleName = table.Rows[i].ItemArray[2].ToString(),
          BrDate = ((DateTime)table.Rows[i].ItemArray[3]).ToShortDateString(),
          NumDou = table.Rows[i].ItemArray[4].ToString(),
          PayOut = table.Rows[i].ItemArray[5].ToString()
        };
        mas[i] = item;
      }

      return mas;

    }

    public string[] GetListDou()
    {
      /// TODO: Заменить на хранимую процедуру.
      string SQL = "select isnull(case when Cast(numdou as int)<10 then '0'+numdou else numdou end,'Нет') as Name from [mfc_out].[dbo].[dou_lg]  group by numdou  order by Name";

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

      int countDou = ds.Tables[0].Rows.Count;
      string[] mas = new string[countDou];
      DataTable table = ds.Tables[0];

      for (int i = 0; i < countDou; i++)
      {
        mas[i] = table.Rows[i].ItemArray[0].ToString();
      }

      return mas;
    }
  }
}
