using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.ServiceProcess;
using System.Text;
using System.Threading;


namespace ServiceSincData
{
  public partial class Service1 : ServiceBase
  {
    Timer timer;
    string strWeather = ConfigurationManager.AppSettings["StrWeather"].ToString();
    string strProizCalend = ConfigurationManager.AppSettings["StrDataGov"].ToString();
    int TimeOut = Convert.ToInt32(ConfigurationManager.AppSettings["TimeOut"].ToString());

    public static void GetData(string url, string type)
    {
      string st = "";
      Log.Write("Выполняю запрос по адрессу: " + url);
      string connString = ConfigurationManager.ConnectionStrings["DateBaseSQL"].ConnectionString;
      try
      {
        WebRequest request = WebRequest.Create(url);
        request.Method = "GET";
        WebResponse response = request.GetResponse();
        MemoryStream ms = new MemoryStream();
        using (Stream stream = response.GetResponseStream())
        {
          stream.CopyTo(ms);
          byte[] buf = ms.ToArray();
          st = Encoding.UTF8.GetString(buf);
        }
      }
      catch (Exception ex)
      {
        Log.Write(ex.Message);
      }

      Log.Write("Данные получен");

      try
      {
        Log.Write("Начинаю процесс обновления Базы данных");
        
        SqlConnection conn = new SqlConnection(connString);
        SqlCommand command = new SqlCommand()
        {
          Connection = conn,
          CommandType = System.Data.CommandType.Text,
          CommandText = "UPDATE [AisInfoDB].[dbo].[ModelDictionaries] SET [Value] = @val WHERE Type = @type"
        };
        command.Parameters.Add(new SqlParameter() { ParameterName = "@val", Value = st });
        command.Parameters.Add(new SqlParameter() { ParameterName = "@type", Value = type });

        conn.Open();
          Log.Write("Изменено: " + command.ExecuteNonQuery());
        conn.Close();
        Log.Write("Данные обновленны");
      }
      catch (Exception ex)
      {
        Log.Write(ex.Message);
      }
    }


    private void UpdateDate(object obj)
    {
      Log.Write("Начинаем процедуру обновления данных");

      


      GetData(strWeather, "0");
      GetData(strProizCalend, "1");


      Log.Write("Начинаем процедуру обновления данных");
    }


    public Service1()
    {
      InitializeComponent();
    }

    protected override void OnStart(string[] args)
    {
      

      timer = new Timer(new TimerCallback(UpdateDate),null,0,TimeOut);

    }

    protected override void OnStop()
    {
    }
  }
}
