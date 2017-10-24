using System;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Text;

namespace SincExportData
{
  class Program
  {

    static string strWeather = "http://api.wunderground.com/api/9fd5b8fea794e554/conditions/lang:RU/q/Russia/Magadan.json";
    static string strProizCalend = "http://data.gov.ru/api/json/dataset/7708660670-proizvcalendar/version/20151123T183036/content?access_token=77a8ff7daf13eb052a970db6665224f0";
    static string connString = "Data Source = 10.49.1.14; Initial Catalog = AisInfoDB; Persist Security Info = True; User ID = c3user; Password = 12345";

    public static void GetData(string url, string type)
    {
      string st = "";

      Console.WriteLine("Выполняю запрос по адрессу: " + url);

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
      response.Close();
      Console.WriteLine("Данные получены");
      Console.WriteLine("Начиная процесс обновления Базы данных");

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
      Console.WriteLine("Изменено: " + command.ExecuteNonQuery());
      conn.Close();

      Console.WriteLine("Данные обновленны");
    }

    static void Main(string[] args)
    {
      Console.WriteLine("Начинаю операцию обновления данных");

      Program.GetData(strWeather, "0");
      Console.ReadLine();
      Program.GetData(strProizCalend, "1");


      Console.WriteLine("Все Операции завершены");


      Console.ReadLine();
    }
  }
}

// 77a8ff7daf13eb052a970db6665224f0 - Ключ к открытым данным
//http://data.gov.ru/api/dataset/?access_token=77a8ff7daf13eb052a970db6665224f0