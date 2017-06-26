using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SincApp
{
  class Program
  {
    static void Main(string[] args)
    {
      string str = "http://api.wunderground.com/api/9fd5b8fea794e554/conditions/lang:RU/q/Russia/Magadan.json";

      WebRequest request = WebRequest.Create(str);
      WebResponse response = request.GetResponse();
      using (Stream stream = response.GetResponseStream())
      {
        using (StreamReader reader = new StreamReader(stream))
        {
          string line = "";
          while ((line = reader.ReadLine()) != null)
          {
            Console.WriteLine(line);
          }
        }

      }

      response.Close();
      Console.WriteLine("Запрос выполнен");
        Console.ReadLine();
    }
    //
  }
}
