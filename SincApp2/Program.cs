using Newtonsoft.Json;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SincApp2
{
  class Program
  {
    static void Main(string[] args)
    {



      
      
      
      
      {
        Task.Delay(5000);
        try
        {
          
          WebRequest request = WebRequest.Create(str);
          request.Method = "GET";
          WebResponse response = request.GetResponse();
          MemoryStream ms = new MemoryStream();
          using (Stream stream = response.GetResponseStream())
          {
            stream.CopyTo(ms);
            byte[] buf = ms.ToArray();
            string st = Encoding.UTF8.GetString(buf);
            RootObject root = JsonConvert.DeserializeObject<RootObject>(st);

            Console.WriteLine(root.current_observation.temp_c);
            Console.WriteLine(root.current_observation.windchill_c);
            Console.WriteLine(st.Length.ToString());
            Console.WriteLine();
          }
          //feelslike_c - ощущается как.
          // windchill_c - температура с учетом ветра
          // relative_humidity - влажность

          Console.WriteLine();

          response.Close();
          Console.WriteLine("Запрос выполнен");
        }
        catch (Exception e)
        {
          Console.WriteLine(e.ToString());
          
        }
      }




      //try
      //{
      //  // Please replace the connection string attribute settings
      //  string constr = "User Id=pvd;Password=pvd;Data Source=10.49.1.3";

      //  OracleConnection con = new OracleConnection(constr);
      //  con.Open();
      //  Console.WriteLine("Connected to Oracle Database {0}", con.ServerVersion);
      //  con.Dispose();

      //  Console.WriteLine("Press RETURN to exit.");
      //  Console.ReadLine();
      //}
      //catch (Exception ex)
      //{
      //  Console.WriteLine("Error : {0}", ex);
      //}




      Console.ReadLine();
    }
    //
  }
}

